     public Form1()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = false;
        }
        public int scrollValue = 0;
        public int ScrollValue
        {
            get
            {
                
                return scrollValue;
            }
            set
            {
                scrollValue = value;
                if (scrollValue < flowLayoutPanel1.VerticalScroll.Minimum )
                {
                    scrollValue = flowLayoutPanel1.VerticalScroll.Minimum;
                }
                if (scrollValue > flowLayoutPanel1.VerticalScroll.Maximum)
                {
                    scrollValue = flowLayoutPanel1.VerticalScroll.Maximum;
                }
                flowLayoutPanel1.VerticalScroll.Value = scrollValue;
                flowLayoutPanel1.PerformLayout();
            }
        } 
        private void Add_Control(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Add(new Button(){Width = flowLayoutPanel1.Width, Height = 87});
        }
        private void UpClick(object sender, EventArgs e)
        {
            ScrollValue -= flowLayoutPanel1.VerticalScroll.LargeChange;
            
        }
        private void DownClick(object sender, EventArgs e)
        {
            ScrollValue += flowLayoutPanel1.VerticalScroll.LargeChange;
        }
