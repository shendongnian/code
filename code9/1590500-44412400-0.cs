        musica mus;
        public Form1()
        {
            InitializeComponent();
            mus = new musica();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                mus.Play(); ;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                mus.Stop();
            }
        }
