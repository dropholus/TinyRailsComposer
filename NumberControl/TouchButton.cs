using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MyControls
{
	[DefaultEvent("Click")]
	public class Button: UserControl, IDisposable, System.ComponentModel.INotifyPropertyChanged
	{
		#region enums
		public enum ButtonStates
		{
			Normal = 0x0001,
			Pressed = 0x0002,
			OutOfRange = 0x0004,
			Checked = 0x0008,
		}

		#endregion enums

		#region Variablen

		private PixelFormat	BitmapPixelFormat = PixelFormat.Format32bppArgb;
		private Bitmap ForegroundBmp;


		private Rectangle[] RectButtonSourceNew		= new Rectangle[9];
		private Rectangle[] RectSymbolSourceNew		= new Rectangle[9];
		private Rectangle[] RectBorderSourceNew		= new Rectangle[9];
		private Rectangle[] RectPressedSourceNew	= new Rectangle[9];
		private Rectangle[] RectDestNew				= new Rectangle[9];

		//private Image BtnImagePressed;
		private Image BtnImageDefault;
		private static Image BtnBorderDefault		= null;

		private MouseEventArgs	MouseArgs		= new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 1, 0, 0, 0);
		
		#endregion Variablen

		private void InitializeComponent()
		{
			this.SuspendLayout();
			//
			// Button
			//
			this.BackColor = System.Drawing.Color.Transparent;
			this.DoubleBuffered = true;
			this.Name = "Button";
			this.ResumeLayout(false);
		}

		public Button()
		{
			base.SetStyle(
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.Opaque |
				ControlStyles.OptimizedDoubleBuffer |
				ControlStyles.ResizeRedraw |
				ControlStyles.StandardClick |
				ControlStyles.SupportsTransparentBackColor |
				ControlStyles.UserMouse |
				ControlStyles.UserPaint, true);
			// nur hier im Control
			SetStyle(ControlStyles.Selectable, false);

			InitializeComponent();

			SetRect(ref RectButtonSourceNew, this.DefaultSize.Width, this.DefaultSize.Height);
			SetRect(ref RectSymbolSourceNew, this.DefaultSize.Width, this.DefaultSize.Height);
			SetRect(ref RectBorderSourceNew, this.DefaultSize.Width, this.DefaultSize.Height);
			SetRect(ref RectPressedSourceNew, this.DefaultSize.Width, this.DefaultSize.Height);
			SetRect(ref RectDestNew, this.Width, this.Height);
		}

		public void OnButtonClick()
		{
			base.OnClick(MouseArgs);
			base.OnMouseClick(MouseArgs);
		}

		#region Eigenschaften

		public Padding _Rounding = new Padding(9);

		[Browsable(true), Category("Appearance"), DefaultValue(typeof(Color), "Control"), Description("Legt die Größe der Schrift fest.")]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
				RedrawButton();
			}
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool _ClickOnMouseUp = false;

		[Browsable(true), Category("Behavior"), DefaultValue(true), Description("Stellt ein, dass der Click bei MouseUp ausgelöst werden soll.")]
		public bool ClickOnMouseUp
		{
			get
			{
				return _ClickOnMouseUp;
			}
			set
			{
				if ( !value.Equals(_ClickOnMouseUp) )
				{
					_ClickOnMouseUp = value;
				}
			}
		}

		[Browsable(false)]
		public new BorderStyle BorderStyle
		{
			get { return BorderStyle.None; }
			set { }
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private Image _ButtonImage;

		[Browsable(true), Category("Appearance"), DefaultValue(null), Description("Hintergrund des Buttons.")]
		public Image ButtonImage
		{
			get
			{
				return _ButtonImage;
			}
			set
			{
				_ButtonImage = value;

				if ( null != _ButtonImage )
				{
					SetRect(ref RectButtonSourceNew, _ButtonImage.Width, _ButtonImage.Height);
					SetRect(ref RectDestNew, this.Width, this.Height);
				}
				RedrawButton();
			}
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private System.Drawing.ContentAlignment _ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;

		[Browsable(true), Category("Appearance"), DefaultValue(System.Drawing.ContentAlignment.MiddleCenter), Description("Positioniert das Bild auf dem Button.")]
		public System.Drawing.ContentAlignment ImageAlign
		{
			get
			{
				return _ImageAlign;
			}
			set
			{
				if ( !value.Equals(_ImageAlign) )
				{
					_ImageAlign = value;
					RedrawButton();
				}
			}
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private Image _SymbolImage;

		[Browsable(true), Category("Appearance"), DefaultValue(null), Description("Symbol, das auf dem Hintergrund angezeigt wird.")]
		public Image SymbolImage
		{
			get
			{
				return _SymbolImage;
			}
			set
			{
				_SymbolImage = value;

				if ( null != _SymbolImage )
				{
					SetRect(ref RectSymbolSourceNew, _SymbolImage.Width, _SymbolImage.Height);
					SetRect(ref RectDestNew, this.Width, this.Height);
				}
				RedrawButton();
			}
		}
		
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private Image _BorderImage;

		[Browsable(true), Category("Appearance"), DefaultValue(null), Description("Rahmen, der über den Button gelegt wird.")]
		public Image BorderImage
		{
			get
			{
				return _BorderImage;
			}
			set
			{
				_BorderImage = value;

				if ( null != _BorderImage )
				{
					SetRect(ref RectBorderSourceNew, _BorderImage.Width, _BorderImage.Height);
					SetRect(ref RectDestNew, this.Width, this.Height);
				}
				RedrawButton();
			}
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private Image _PressedImage;

		[Browsable(true), Category("Appearance"), DefaultValue(null), Description("Bild, das über den Button im gedrückten Zustand gelegt wird.")]
		public Image PressedImage
		{
			get
			{
				return _PressedImage;
			}
			set
			{
				_PressedImage = value;

				if ( null != _PressedImage )
				{
					SetRect(ref RectPressedSourceNew, _PressedImage.Width, _PressedImage.Height);
					SetRect(ref RectDestNew, this.Width, this.Height);
				}
				RedrawButton();
			}
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool _BorderImageVisible = true;

		[Browsable(true), Category("Appearance"), DefaultValue(true), Description("Verhindert bei false, das Zeichen des Rahmen-Bildes.")]
		public bool BorderImageVisible
		{
			get
			{
				return _BorderImageVisible;
			}
			set
			{
				if ( !value.Equals(_BorderImageVisible) )
				{
					_BorderImageVisible = value;
					RedrawButton();
				}
			}
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool _OverlayImageVisible = true;

		[Browsable(true), Category("Appearance"), DefaultValue(true), Description("Verhindert bei false, das Zeichen des Overlay-Bildes.")]
		public bool OverlayImageVisible
		{
			get
			{
				return _OverlayImageVisible;
			}
			set
			{
				if ( !value.Equals(_OverlayImageVisible) )
				{
					_OverlayImageVisible = value;
					RedrawButton();
				}
			}
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool _SymbolImageVisible = true;

		[Browsable(true), Category("Appearance"), DefaultValue(true), Description("Verhindert bei false, das Zeichen des Symbol-Bildes.")]
		public bool SymbolImageVisible
		{
			get
			{
				return _SymbolImageVisible;
			}
			set
			{
				if ( !value.Equals(_SymbolImageVisible) )
				{
					_SymbolImageVisible = value;
					RedrawButton();
				}
			}
		}


		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private ButtonStates _ButtonState = ButtonStates.Normal;

		[Browsable(true), Category("Appearance"), DefaultValue(ButtonStates.Normal)]
		public ButtonStates ButtonState
		{
			get
			{
				return _ButtonState;
			}
			set
			{
				_ButtonState = value;

				RedrawButton();
			}
		}


		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private bool _Enabled = true;

		[Bindable(true)]
		[Browsable(true), Category("Behavior"), DefaultValue(true), Description("Gibt an, ob der Button aktiv ist.")]
		public new bool Enabled
		{
			get
			{
				return _Enabled;
			}
			set
			{
				if ( _Enabled != value )
				{
					//_Enabled = value;
					CheckSetAndSend(ref _Enabled, value);
					RedrawButton();
				}
			}
		}

		[Browsable(true), Category("Appearance"), Description("Der Text, der auf dem Control dargestellt werden soll.")]
		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor)), SettingsBindable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				if ( value != base.Text )
				{
					base.Text = value;
					RedrawButton();
				}
			}
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private TextRenderingHint _TextRenderingHint = TextRenderingHint.AntiAlias;

		[Browsable(true), Category("Appearance"), DefaultValue(TextRenderingHint.AntiAlias), Description("Legt fest, ob der Text aliased gezeichnet werden soll oder nicht.")]
		public TextRenderingHint TextRenderingHint
		{
			get
			{
				return _TextRenderingHint;
			}
			set
			{
				_TextRenderingHint = value;
				RedrawButton();
			}
		}

		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		private Color _Color = Color.LightBlue;

		[Browsable(true), Category("Appearance"), DefaultValue(TextRenderingHint.AntiAlias), Description("Legt die Farbe des Buttons fest.")]
		public Color Color
		{
			get
			{
				return _Color;
			}
			set
			{
				_Color = value;
				SwitchColorScheme();
				RedrawButton();
			}
		}

		#endregion Eigenschaften

		private Image SetBackground(Color upper, Color lower)
		{
			Image img = new Bitmap(48, 40, BitmapPixelFormat);
			Graphics graphics = Graphics.FromImage(img);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			try
			{
				Rectangle rect = new Rectangle(2, 2, 44, 36);
				System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(rect, upper, lower, 90.0F);
				DrawRoundedRectangle(graphics, 2, 2, 44, 36, _Rounding, brush, null);
				graphics.Dispose();
			}
			catch { graphics.Dispose(); }

			return img;
		}

		private void SwitchColorScheme()
		{
			//BtnImagePressed = SetBackground(Color.FromArgb(64, 0, 0, 0), Color.FromArgb(64, 0, 0, 0));
			//BtnImageDefault = SetBackground(Color.FromArgb(45, 83, 202), Color.FromArgb(76, 152, 223));
			BtnImageDefault = SetBackground(_Color, _Color);
		}

		private void RenderText(object sender, Graphics graphics, string text)
		{
			using ( Font myFont = new Font(Font.FontFamily, Font.Size, Font.Style) )
			{
				//float height = myFont.GetHeight();
				SizeF size = graphics.MeasureString(text, myFont);
				int PointX = this.Width / 2 - (int)size.Width / 2;
				int PointY = this.Height / 2 - (int)size.Height / 2;

				if ( Enabled )
				{
					Brush solidBrush = new SolidBrush(ForeColor);
					graphics.DrawString(text, myFont, solidBrush, new Point(PointX, PointY));
				}
				else
				{
					Brush solidBrush = new SolidBrush(Color.DimGray);
					graphics.DrawString(text, myFont, solidBrush, new Point(PointX, PointY));
				}
			}
		}

		private void SetRect(ref Rectangle[] rect, int width, int height)
		{
			rect[0] = new Rectangle(0, 0, _Rounding.Left, _Rounding.Top);
			rect[1] = new Rectangle(_Rounding.Left, 0, width - (_Rounding.Left + _Rounding.Right), _Rounding.Top);
			rect[2] = new Rectangle(width - _Rounding.Right, 0, _Rounding.Right, _Rounding.Top);

			rect[3] = new Rectangle(0, _Rounding.Top, _Rounding.Left, height - (_Rounding.Top + _Rounding.Bottom));
			rect[4] = new Rectangle(_Rounding.Left, _Rounding.Top, width - (_Rounding.Left + _Rounding.Right), height - (_Rounding.Top + _Rounding.Bottom));
			rect[5] = new Rectangle(width - _Rounding.Right, _Rounding.Top, _Rounding.Right, height - (_Rounding.Top + _Rounding.Bottom));

			rect[6] = new Rectangle(0, height - _Rounding.Bottom, _Rounding.Left, _Rounding.Bottom);
			rect[7] = new Rectangle(_Rounding.Left, height - _Rounding.Bottom, width - (_Rounding.Left + _Rounding.Right), _Rounding.Bottom);
			rect[8] = new Rectangle(width - _Rounding.Right, height - _Rounding.Bottom, _Rounding.Right, _Rounding.Bottom);
		}

		private void SetRectAllRounding()
		{
			if ( null != ButtonImage )
			{
				SetRect(ref RectButtonSourceNew, ButtonImage.Width, ButtonImage.Height);
			}
			if ( null != SymbolImage )
			{
				SetRect(ref RectSymbolSourceNew, SymbolImage.Width, SymbolImage.Height);
			}
			if ( null != BorderImage )
			{
				SetRect(ref RectBorderSourceNew, BorderImage.Width, BorderImage.Height);
			}
			if ( null != PressedImage )
			{
				SetRect(ref RectPressedSourceNew, PressedImage.Width, PressedImage.Height);
			}
			
			SetRect(ref RectDestNew, this.Width, this.Height);
		}

		public void DrawImage(Graphics graphics, Image image, Rectangle[] rect)
		{
			if ( null != image )
			{
				for ( int i = 0; i < rect.Length; i++ )
				{
					graphics.DrawImage(image, RectDestNew[i], rect[i], GraphicsUnit.Pixel);
				}
			}
		}

		public void DrawImage(Graphics graphics, Image image, Rectangle[] rect, Point[] dest, ImageAttributes attr)
		{
			if ( null != image )
			{
				for ( int i = 0; i < rect.Length; i++ )
				{
					graphics.DrawImage(image, dest, rect[i], GraphicsUnit.Pixel, attr);
				}
			}
		}

		public static void DrawRoundedRectangle(Graphics graphics, int x, int y, int width, int height, Padding rounding, Brush fillBrush, Pen linePen)
		{
			GraphicsPath gp = new GraphicsPath();
			// Ecke rechts oben
			gp.AddArc(x + width - rounding.Right - 1, y, rounding.Right, rounding.Top, 270, 90);
			// Ecke rechts unten
			gp.AddArc(x + width - rounding.Right - 1, y + height - rounding.Bottom - 1, rounding.Right, rounding.Bottom, 0, 90);
			// Ecke links unten
			gp.AddArc(x, y + height - rounding.Bottom - 1, rounding.Left, rounding.Bottom, 90, 90);
			// Ecke links oben
			gp.AddArc(x, y, rounding.Left, rounding.Top, 180, 90);
			// Die Figur abschließen
			gp.CloseFigure();

			// Den Pfad mit dem übergebenen Pinsel füllen
			if ( fillBrush != null )
			{
				graphics.FillPath(fillBrush, gp);
			}

			// Die Linien des Pfades zeichnen
			if ( linePen != null )
			{
				graphics.DrawPath(linePen, gp);
			}
		}

		private void DrawBtn(Graphics graphics)
		{
			bool saved = _Enabled;
			_Enabled = true;
			//Point[] pointInner = new Point[] { new Point(0, 0), new Point(this.Width, 0), new Point(0, this.Height) };

			#region ButtonImage

			if ( ButtonImage == null ) // Standardbild nehmen
			{
					DrawImage(graphics, BtnImageDefault, RectButtonSourceNew);
			}
			else
			{
					DrawImage(graphics, ButtonImage, RectButtonSourceNew);
			}

			#endregion ButtonImage

			_Enabled = saved;

			if ( SymbolImageVisible )
			{
				#region SymbolImage
				if ( _SymbolImage != null )
				{
					Point[] pointInnerImageAlign = null;
					int left1 = 0;
					int left2 = 0;
					int top1 = 0;
					int top2 = 0;

					switch ( ImageAlign )
					{
					case ContentAlignment.TopLeft:
					case ContentAlignment.MiddleLeft:
					case ContentAlignment.BottomLeft:
						left1 = 0;
						left2 = SymbolImage.Width;
						break;

					case ContentAlignment.TopCenter:
					case ContentAlignment.MiddleCenter:
					case ContentAlignment.BottomCenter:
						left1 = ClientRectangle.Width / 2 - SymbolImage.Width / 2;
						left2 = this.Width / 2 + SymbolImage.Width / 2;
						break;

					case ContentAlignment.TopRight:
					case ContentAlignment.MiddleRight:
					case ContentAlignment.BottomRight:
						left1 = ClientRectangle.Width - SymbolImage.Width;
						left2 = this.Width;
						break;
					};

					switch ( ImageAlign )
					{
					case ContentAlignment.TopLeft:
					case ContentAlignment.TopCenter:
					case ContentAlignment.TopRight:
						top1 = 0;
						top2 = SymbolImage.Height;
						break;
					case ContentAlignment.MiddleLeft:
					case ContentAlignment.MiddleCenter:
					case ContentAlignment.MiddleRight:
						top1 = ClientRectangle.Height / 2 - SymbolImage.Height / 2;
						top2 = ClientRectangle.Height / 2 + SymbolImage.Height / 2;
						break;
					case ContentAlignment.BottomLeft:
					case ContentAlignment.BottomCenter:
					case ContentAlignment.BottomRight:
						top1 = ClientRectangle.Height - SymbolImage.Height;
						top2 = ClientRectangle.Height;
						break;
					};

					pointInnerImageAlign = new Point[] { new Point(left1, top1), new Point(left2, top1), new Point(left1, top2) };

					graphics.DrawImage(SymbolImage, pointInnerImageAlign, new Rectangle(new Point(0, 0), SymbolImage.Size), GraphicsUnit.Pixel);
				}
				#endregion SymbolImage
			}

			if ( this.Text != "" )
			{
				RenderText(this, graphics, this.Text);
			}

			_Enabled = true;

			if ( BorderImageVisible )
			{
				#region BorderImage

				if ( _BorderImage == null ) // Standardbild nehmen
				{
					DrawImage(graphics, BtnBorderDefault, RectBorderSourceNew);
				}
				else
				{
					DrawImage(graphics, BorderImage, RectBorderSourceNew);
				}

				#endregion BorderImage
			}

			_Enabled = saved;
		}

		private bool MouseInnertControl(int x, int y)
		{
			if ( (x > 0) && (x < this.Width)
			&& (y > 0) && (y < this.Height) )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void RedrawButton()
		{
			//if ( Parent != null && !(bool)typeof(Control).GetProperty("IsLayoutSuspended", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(Parent, null) )
			{
				this.Invalidate();
			}
		}

		public new bool CanFocus
		{
			get
			{
				return false;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			// ++ http://stackoverflow.com/questions/1086621/drawing-a-transparent-button
			if ( this.Parent != null )
			{
				GraphicsContainer cstate = e.Graphics.BeginContainer();

				e.Graphics.TranslateTransform(-this.Left, -this.Top);
				Rectangle clip = e.ClipRectangle;
				clip.Offset(this.Left, this.Top);

				PaintEventArgs pe = new PaintEventArgs(e.Graphics, clip);
				//paint the container's bg
				InvokePaintBackground(this.Parent, pe);
				//paints the container fg
				InvokePaint(this.Parent, pe);

				//restores graphics to its original state
				e.Graphics.EndContainer(cstate);
			}
			else
			{
				base.OnPaint(e); // or base.OnPaint(pevent);...
			}
			// -- http://stackoverflow.com/questions/1086621/drawing-a-transparent-button
			RedrawForeground();

			e.Graphics.DrawImage(ForegroundBmp, ClientRectangle, ClientRectangle, GraphicsUnit.Pixel);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			SetRectAllRounding();
			SwitchColorScheme(); // Wegen ColorScheme Background-Verlauf
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			MouseArgs = e;

			if ( e.Button == MouseButtons.Left )
			{
				_ButtonState = ButtonStates.Pressed;

				RedrawButton();

				if ( !ClickOnMouseUp && Enabled )
				{
					base.OnClick(e);
					base.OnMouseClick(e);
				}
			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			switch ( _ButtonState )
			{
			case ButtonStates.OutOfRange:
				{
					_ButtonState = ButtonStates.Pressed;
					RedrawButton();
				}
				break;
			};
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			switch ( _ButtonState )
			{
			case ButtonStates.Pressed:
				{
					_ButtonState = ButtonStates.OutOfRange;
					RedrawButton();
				}
				break;
			};
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if ( e.Button == MouseButtons.Left )
			{
				_ButtonState = ButtonStates.Normal;

				RedrawButton();

				if ( ClickOnMouseUp && Enabled && MouseInnertControl(e.X, e.Y) )
				{
					base.OnClick(e);
					base.OnMouseClick(e);
				}
			}
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			//base.OnMouseClick(e);
		}

		protected override void OnClick(EventArgs e)
		{
			//base.OnClick(e);
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			if ( Parent != null )
			{
				Enabled = Parent.Enabled;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			SwitchColorScheme();
		}

		private void RedrawForeground()
		{
			ForegroundBmp = new Bitmap(this.Width, this.Height, BitmapPixelFormat);
			Graphics graphics = Graphics.FromImage((Image)ForegroundBmp);
			graphics.SmoothingMode = SmoothingMode.None;

			graphics.Clear(Color.FromArgb(0, 0, 0, 0));
			DrawBtn(graphics);
			graphics.Dispose();
		}

		protected override void Dispose(bool disposing)
		{
			if ( disposing )
			{
				if ( ForegroundBmp != null )
				{
					ForegroundBmp.Dispose();
				}
			}

			base.Dispose(disposing);
		}

		public new event EventHandler Disposed;
		
		public new void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);

			EventHandler DisposedFinised = Disposed;

			if ( DisposedFinised != null )
			{
				DisposedFinised(this, EventArgs.Empty);
			}
		}

		protected override Size DefaultSize
		{
			get { return new Size(48, 40); }
		}

		#region INotifyPropertyChanged Members

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;

			if ( handler != null )
			{
				if ( System.Windows.Forms.Application.OpenForms.Count > 0 )
				{
					System.Windows.Forms.Form mainForm = System.Windows.Forms.Application.OpenForms[0];

					if ( mainForm != null )
					{
						if ( mainForm.InvokeRequired )
						{
							// We are not in UI Thread now
							mainForm.Invoke(handler, new object[] { this, new System.ComponentModel.PropertyChangedEventArgs(propertyName) });
						}
						else
						{
							handler(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
						}
					}
				}
			}
		}

		protected bool CheckSetAndSend<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
		{
			if ( System.Collections.Generic.EqualityComparer<T>.Default.Equals(field, value) )
			{
				return false;
			}

			field = value;

			OnPropertyChanged(propertyName);

			return true;
		}

		#endregion INotifyPropertyChanged Members
	}
}
