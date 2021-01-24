    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			var button1 = NewButton(0);
			button1.Location = new Point(10, 10);
			var button2 = NewButton(1);
			button2.Location = new Point(button1.Right, 10);
			var button3 = NewButton(2);
			button3.Location = new Point(button2.Right, 10);
			button3.Resize += (s, e) =>
			{
				button2.Location = new Point(button1.Right, 10);
				button3.Location = new Point(button2.Right, 10);
			};
			Controls.Add(button1);
			Controls.Add(button2);
			Controls.Add(button3);
		}
		private Button NewButton(int index)
		{
			return new Button()
			{
				Text = "ButtonButtonButton" + index.ToString(),
				AutoSize = true
			};
		}
	}
