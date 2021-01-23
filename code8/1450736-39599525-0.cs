        private string text;
        public Form1()
        {
            InitializeComponent();
            text = this.buttonTwo.Text;
        }
        private void buttonTwo_Click(object sender, EventArgs e)
        {
            sayingTwo.Visible = true;
            buttonTwo.Text = "Click To Hide Saying";
            buttonTwo.Click -= buttonTwo_Click2;
            buttonTwo.Click += buttonTwo_Click2;
        }
        private void buttonTwo_Click2(object sender, EventArgs e)
        {
            if (sayingTwo.Visible == true)
            {
                buttonTwo.Enabled = false;
                sayingTwo.Visible = false;
                buttonTwo.Text = "Reactivating in 5 seconds";
                tm2.Interval = 1000;
                buttonTwo.Click -= buttonTwo_Click2;
                tm2.Tick += timer2_Tick;
                tm2.Enabled = true;
            }
        }
        int ii = 4;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ii != 0)
            {
                buttonTwo.Text = "Reactivating in " + ii + " seconds";
                ii -= 1;
            }
            else
            {
                tm2.Enabled = false;
                tm2.Tick -= timer2_Tick;
                buttonTwo.Enabled = true;
                this.buttonTwo.Text = this.text;
                ii += 4;
            }
        }
