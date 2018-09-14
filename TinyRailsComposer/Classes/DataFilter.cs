using System;
using System.Collections.Generic;
using System.Reflection;

namespace TinyRails_Composer
{
	internal class DataFilter
	{
		private string _Filter = "";

		private List<Statement> _Statements = new List<Statement>();

		internal DataFilter(string filter)
		{
			_Filter = filter;

			ParseFilter();
		}

		internal bool Validate(ResourceData pdata)
		{
			if ( _Filter == "" )
				return true;

			bool validate = false;
			foreach ( var statement in _Statements )
				validate |= statement.Validate(pdata);

			return validate;
		}

		internal static bool ValidateFilterString(string filter)
		{
			string[] orStatements = filter.Trim().Split(new string[] { "OR" }, StringSplitOptions.RemoveEmptyEntries);

			foreach ( var orStatement in orStatements )
			{
				string[] andStatements = orStatement.Trim().Split(new string[] { "AND" }, StringSplitOptions.RemoveEmptyEntries);

				if ( andStatements.Length > 1 )
				{
					//List<Statement> andStatementList = new List<Statement>();
					foreach ( var andStatement in andStatements )
					{
						string[] split = andStatement.Trim().Split(new char[] { '=' });
						if ( split.Length != 2 || typeof(ResourceData).GetProperty(split[0]) == null )
							return false;
					}
				}
				else
				{
					string[] split = orStatement.Trim().Split(new char[] { '=' });
					if ( split.Length != 2 || typeof(ResourceData).GetProperty(split[0]) == null )
						return false;
				}
			}

			return true;
		}

		private void ParseFilter()
		{
			string[] orStatements = _Filter.Trim().Split(new string[] { "OR" }, StringSplitOptions.RemoveEmptyEntries);

			foreach ( var orStatement in orStatements )
			{
				string[] andStatements = orStatement.Trim().Split(new string[] { "AND" }, StringSplitOptions.RemoveEmptyEntries);

				if ( andStatements.Length > 1 )
				{
					List<Statement> andStatementList = new List<Statement>();
					foreach ( var andStatement in andStatements )
					{
						string[] split = andStatement.Trim().Split(new char[] { '=' });
						if ( split.Length == 2 )
							andStatementList.Add(new Statement(split[0], split[1]));
					}
					_Statements.Add(new Statement(andStatementList));
				}
				else
				{
					string[] split = orStatement.Trim().Split(new char[] { '=' });
					if ( split.Length == 2 )
						_Statements.Add(new Statement(split[0], split[1]));
				}
			}
		}

		[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
		public class Statement
		{
			#region DebuggerDisplay

			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
			private string DebuggerDisplay
			{
				get
				{
					if ( _PropertyName == string.Empty && _PropertyValue == string.Empty )
					{
						return string.Format("List.Count={0}", _Statements.Count);
					}
					else
					{
						return string.Format("Name={0}, Value={1}, Operation={2}", _PropertyName, _PropertyValue, _ValueOperation);
					}
				}
			}

			#endregion DebuggerDisplay

			private enum EPropertyValueOperation
			{
				None, StartsWith, EndsWith, Contains, Equals
			}

			private List<Statement> _Statements = new List<Statement>();

			private string _PropertyName = string.Empty;
			private string _PropertyValue = string.Empty;
			private EPropertyValueOperation _ValueOperation;

			public Statement(string name, string value)
			{
				_PropertyName = name;

				if ( value.StartsWith("*") )
				{
					if ( value.EndsWith("*") )
						_ValueOperation = EPropertyValueOperation.Contains;
					else
						_ValueOperation = EPropertyValueOperation.EndsWith;
				}
				else if ( value.EndsWith("*") )
				{
					_ValueOperation = EPropertyValueOperation.StartsWith;
				}
				else
				{
					_ValueOperation = EPropertyValueOperation.Equals;
				}

				_PropertyValue = value.Trim().Replace("*", "");
			}

			public Statement(List<Statement> andBlock)
			{
				_Statements.AddRange(andBlock);
			}

			public bool Validate(ResourceData pdata)
			{
				if ( _Statements.Count == 0 )
				{
					PropertyInfo pdProperty = typeof(ResourceData).GetProperty(_PropertyName);
					if ( pdProperty != null )
					{
						string pdFieldValue = pdProperty.GetValue(pdata).ToString();

						switch ( _ValueOperation )
						{
						case EPropertyValueOperation.StartsWith:
							return pdFieldValue.StartsWith(_PropertyValue);
						case EPropertyValueOperation.EndsWith:
							return pdFieldValue.EndsWith(_PropertyValue);
						case EPropertyValueOperation.Contains:
							return pdFieldValue.Contains(_PropertyValue);
						case EPropertyValueOperation.Equals:
							return pdFieldValue.Equals(_PropertyValue);
						default:
							return false;
						}
					}

					return false;
				}
				else
				{
					bool validate = true;
					foreach ( var statement in _Statements )
						validate &= statement.Validate(pdata);

					return validate;
				}
			}
		}
	}
}
