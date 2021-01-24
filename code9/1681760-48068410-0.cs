     SoundPlayer pla = new SoundPlayer(Properties.Resources._3);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = this.BackColor;
            this.Left = 0;
            this.Top = 0;
            this.Opacity = 0; //This line added 
            this.Width = Screen.PrimaryScreen.Bounds.Width / 2;
            this.Height = Screen.PrimaryScreen.Bounds.Height / 2;
            this.BackgroundImage = Properties.Resources._1; //We set the image once here
            this.TopMost = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Minute == 15)
            {
                this.Opacity = 1; //We show the window
                System.Threading.Thread.Sleep(500);
                pla.Play();
                this.Opacity = 0; //We hide the window
            }
        }
  
