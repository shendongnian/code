    public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = false;
        }
        public int value { get; set; } = 0;
        private void Add_Control_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Add(new Button(){Width = flowLayoutPanel1.Width, Height = 87});
        }
        private void Up_Click(object sender, EventArgs e)
        {
            value -= flowLayoutPanel1.VerticalScroll.LargeChange;
            flowLayoutPanel1.VerticalScroll.Value = value;
            flowLayoutPanel1.PerformLayout();
        }
        private void Down_Click(object sender, EventArgs e)
        {
            value += flowLayoutPanel1.VerticalScroll.LargeChange;
            flowLayoutPanel1.VerticalScroll.Value = value;
            flowLayoutPanel1.PerformLayout();
        }
