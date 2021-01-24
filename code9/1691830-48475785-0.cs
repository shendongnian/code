	public Form1()
	{
		InitializeComponent();
		//attach same click handler on *all *buttons.
		//that can be made like this, in form constructor, or via form designer
		button1.Click += Button_Click;
		button2.Click += Button_Click;
		button3.Click += Button_Click;
		button4.Click += Button_Click;
		//etc...
		//notice that right part is always the samme :)
	}
	//handler method
	private void Button_Click(object sender, EventArgs e)
	{
		//get button that called this method by casting it from object
		var btn = sender as Button;
		//use regex to get number from button and construct panel name
        var number = new Regex(@"\d+").Match(btn.Name);
        var targetPanel = "img" + number.Value.ToString();
		//find all controls of type panel, and then single one that has "targetPanel" name
		var pnl = this.Controls.OfType<Panel>().Single(pnl => pnl.Name == targetPanel):
		//make it invisible
		pnl.Visible = false;
	}
