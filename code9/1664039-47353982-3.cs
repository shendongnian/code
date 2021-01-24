    // running as Console window
    // output from...
    // 1. clicking and releasing on button1
    // 2. clicking and holding on button1 and then releasing not over button1 or button2,
    // 3. clicking and holding on button1 and then 
    // moving mouse to over button2 and releasing mouse.
    // button1 Click
    // button1 Ding!
    // button1 MouseUp
    // button1 MouseUp
    // button1 Ding!
    // button1 MouseUp
    // button1 Ding!
    // button2 Click
    // button2 Ding!
    private List<Button> _buttons { get; set; }
	public Form1()
	{
		InitializeComponent();
		button1.MouseUp += Button_MouseUp;
		button2.MouseUp += Button_MouseUp;
		button1.Click += Button_Click;
		button2.Click += Button_Click;
		button1.Tag = false;
		button2.Tag = false;
		_buttons = new List<Button>()
		{
			button1, button2
		};
	}
	private void Button_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		var button = sender as Button;
		Console.WriteLine($"{button.Text} MouseUp");
		if (!(bool)button.Tag)
			ButtonClick(button);
		else
			button.Tag = false;
		Func<Button, bool> ContainsMouse = (b) =>
		{
			var rect = b.RectangleToScreen(b.DisplayRectangle);
			var pos = GetCursorPosition();
			return rect.Contains(pos.X, pos.Y);
		};
			
		var hoverButton = _buttons.SingleOrDefault(b => ContainsMouse(b));
		if (hoverButton != null && !hoverButton.Equals(button))
			hoverButton.PerformClick();
	}
	private void Button_Click(object sender, EventArgs e)
	{
		var button = sender as Button;
		Console.WriteLine($"{button.Text} Click");
		ButtonClick(button);
		button.Tag = true;
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
