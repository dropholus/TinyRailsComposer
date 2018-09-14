using System;
using System.Text;
using System.Windows.Forms;

namespace MyControls
{
	public partial class NumberControl: UserControl
	{
		private StringBuilder StringNumber = new StringBuilder();
        private string StringPrefix = string.Empty;
        private bool Reuse = false;
        private string ReuseNumber = string.Empty;

		#region Eigenschaften

		public string Number
		{
			get { return StringNumber.ToString(); }
			set { StringNumber = new StringBuilder(Number); }
		}

		#endregion Eigenschaften

		public NumberControl()
		{
			InitializeComponent();
		}

		public class NumberEventArgs: EventArgs
		{
			public enum Dir
			{
				Positive,
				Set,
				Negative,
			}

			public Int32 Number;
			public Dir Direction;

			public NumberEventArgs()
			{
			}

			public NumberEventArgs(Int32 number, Dir direction)
			{
				Number = number;
				Direction = direction;
			}
		}

		public event EventHandler<NumberEventArgs> OnOk;
		public event EventHandler<NumberEventArgs> OnCancel;

		private void UpdateNumber()
		{
			TxtNumber.Text = StringPrefix + StringNumber.ToString();
		}

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            string text = string.Empty;

            if (Reuse)
            {
                StringNumber = new StringBuilder();
            }

            if (sender is System.Windows.Forms.Button)
            {
                text = (sender as System.Windows.Forms.Button).Text;
            }
            else if (sender is MyControls.Button)
            {
                text = (sender as MyControls.Button).Text;
            }

            StringNumber.Append(text);
            UpdateNumber();
            Reuse = false;

        }

		private void BtnBack_Click(object sender, EventArgs e)
		{
			if ( StringNumber.Length > 0 )
			{
                if (Reuse)
                {
                    StringNumber = new StringBuilder();
                    UpdateNumber();
                }
                else
                {
                    StringNumber.Remove(StringNumber.Length - 1, 1);
                    UpdateNumber();
                }
			}
		}

		private void BtnPM_Click(object sender, EventArgs e)
		{
			switch ( StringPrefix )
			{
			case "+":
				StringPrefix = "-";
				break;
			case "-":
				StringPrefix = "";
				break;
			case "":
				StringPrefix = "+";
				break;
			};

			UpdateNumber();
		}

		private void BtnCE_Click(object sender, EventArgs e)
		{
			StringPrefix = "";
			StringNumber.Remove(0, StringNumber.Length);
			UpdateNumber();
            Reuse = false;
        }

		private void Btn_FulFill_Click(object sender, EventArgs e)
		{
            EventHandler<NumberEventArgs> Handler = OnOk;

            if (null != Handler)
            {
                Handler(this, new NumberEventArgs(20000, NumberEventArgs.Dir.Set)); // higher than the highest number of resources, so set and fulfill
            }
        }

		private void BtnOk_Click(object sender, EventArgs e)
		{
			UpdateNumber();

			string s = StringPrefix + StringNumber.ToString();
			NumberEventArgs nea;
			Int32 number = 0;

			Int32.TryParse(StringNumber.ToString(), out number);

			if ( s.StartsWith("+"))
			{
				nea = new NumberEventArgs(number, NumberEventArgs.Dir.Positive);
			}
			else if ( s.StartsWith("-"))
			{
				nea = new NumberEventArgs(number* -1, NumberEventArgs.Dir.Negative);
			}
			else
			{
				nea = new NumberEventArgs(number, NumberEventArgs.Dir.Set);
			}

			EventHandler<NumberEventArgs> Handler = OnOk;

			if ( null != Handler )
			{
				Handler(this, nea);
			}

            ReuseNumber = s;
			TxtNumber.Text = "(" + TxtNumber.Text + ")";

			StringNumber = new StringBuilder();
			StringPrefix = "";
        }

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			UpdateNumber();

			string s = StringNumber.ToString();
			NumberEventArgs nea;

			if ( s.StartsWith("+") )
			{
				nea = new NumberEventArgs(Int32.Parse(StringNumber.ToString()), NumberEventArgs.Dir.Positive);
			}
			else if ( s.StartsWith("-") )
			{
				nea = new NumberEventArgs(Int32.Parse(StringNumber.ToString()), NumberEventArgs.Dir.Negative);
			}
			else
			{
				nea = new NumberEventArgs(Int32.Parse(StringNumber.ToString()), NumberEventArgs.Dir.Set);
			}

			EventHandler<NumberEventArgs> Handler = OnCancel;

			if ( null != Handler )
			{
				Handler(this, nea);
			}
		}

        private void Btn_Reuse_Click(object sender, EventArgs e)
        {
            NumberEventArgs nea;

            Int32 number = 0;

            if (ReuseNumber.StartsWith("+"))
            {
				Int32.TryParse(ReuseNumber.Remove(0, 1), out number);
				nea = new NumberEventArgs(number, NumberEventArgs.Dir.Positive);
            }
            else if (ReuseNumber.StartsWith("-"))
            {
				Int32.TryParse(ReuseNumber.Remove(0, 1), out number);
				nea = new NumberEventArgs(number * -1, NumberEventArgs.Dir.Negative);
            }
            else
            {
				Int32.TryParse(ReuseNumber, out number);
				nea = new NumberEventArgs(number, NumberEventArgs.Dir.Set);
            }

            EventHandler<NumberEventArgs> Handler = OnOk;

            if (null != Handler)
            {
                Handler(this, nea);
            }
        }
    }
}
