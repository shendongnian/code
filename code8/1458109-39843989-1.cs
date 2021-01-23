        public DialogBox()
        {
            InitializeComponent();
            //bind Handler to tick event. You can double click in 
            //properrties>events tab in designer
            timer1.Tick += Timer1_Tick;
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            btnYes.Enabled = true;
            timer1.Stop();
        }
