    // running as Console window
    // output from clicking and holding button1, 
    // then moving mouse to over button2 and releasing mouse.
    // button1 Ding!
    // button2 Ding!
    private List<Button> _buttons { get; set; }
	public Form1()
	{
		InitializeComponent();
		button1.MouseUp += Button_MouseUp;
		button2.MouseUp += Button_MouseUp;
		button1.Click += Button_Click;
		button2.Click += Button_Click;
		_buttons = new List<Button>()
		{
			button1, button2
		};
	}
	private void Button_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		var button = sender as Button;
		ButtonClick(button);
		Func<Button, bool> ContainsMouse = (b) =>
		{
			var rect = b.RectangleToScreen(b.DisplayRectangle);
			var pos = GetCursorPosition();
			return rect.Contains(pos.X, pos.Y);
		};
			
		var hoverButton = _buttons.SingleOrDefault(b => ContainsMouse(b));
                // currently is making button ding twice if click and 
                // release on same button because Equals is not returning false, 
                // attempting to fix now
		if (hoverButton != null && !hoverButton.Equals(button))
			hoverButton.PerformClick();
	}
	private void Button_Click(object sender, EventArgs e)
	{
		var button = sender as Button;
		ButtonClick(button);
	}
	private void ButtonClick(Button button)
	{
		Console.WriteLine($"{button.Text} Ding!");
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		public int X;
		public int Y;
		public static implicit operator Point(POINT point)
		{
			return new Point(point.X, point.Y);
		}
	}
	/// <summary>
	/// Retrieves the cursor's position, in screen coordinates.
	/// </summary>
	/// <see>See MSDN documentation for further information.</see>
	[DllImport("user32.dll")]
	public static extern bool GetCursorPos(out POINT lpPoint);
	public static Point GetCursorPosition()
	{
		POINT lpPoint;
		GetCursorPos(out lpPoint);
		//bool success = User32.GetCursorPos(out lpPoint);
		// if (!success)
		return lpPoint;
	}
