        bool moveLeft = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if((pictureBox1.Left + pictureBox1.Width) >= this.Width)
            {
                moveLeft = true;
            }
            if(pictureBox1.Left < 0)
            {
                moveLeft = false;
            }
            if(moveLeft)
            {
                pictureBox1.Left -= 15;
            }
            if (!moveLeft)
            {
                pictureBox1.Left += 15;
            }
        }
