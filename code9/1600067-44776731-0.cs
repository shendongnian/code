    public Form2()
        {
            InitializeComponent();
            notifyIcon1.Visible = true;
            timer2.Start();
        }
    private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 100;
            timer2.Enabled = true;
            timer2.Tick += changer;
        }
    void changer (object sender, EventArgs e)
        {
            Random color = new Random();
            Color randomColor = Color.FromArgb(color.Next(255), color.Next(255), color.Next(255));
            label1.ForeColor = randomColor;
        }
