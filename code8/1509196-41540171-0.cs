	string time;
	public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        timer1.Enabled = true;
        timer1.Interval = 1000;
        //clockLabel.Text = "00:00:00";
        clockLabel.Text = time;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        time = DateTime.Now.ToString("hh:mm:ss");
        clockLabel.Text = time;
    }
