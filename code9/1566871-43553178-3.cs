    public Form1()
    {
        InitializeComponent();
        var timer1 = new Timer
        {
            Enabled = true,
            Interval = 150
        };
        timer1.Tick += timer1_Tick;
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        textBox1.Text = Cursor.Position.X.ToString();
    }
