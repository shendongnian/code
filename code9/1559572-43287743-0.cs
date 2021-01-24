        private int randy;
        public Form1()
        {
            InitializeComponent();
            Random random1 = new Random();
            randy = random1.Next(0, 5);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (number < randy)
            {
                label1.Text = "Try a higher number"; //tell user to guess
            }
        }
