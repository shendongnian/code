        public Form()
        {
            InitializeComponent();
            this.FormClosing += Form_FormClosing;
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
