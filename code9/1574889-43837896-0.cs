    public Form1()
        {
            InitializeComponent();
                timer.Enabled = false;
                timer.Interval = 2000;                
                timer.Tick += Timer1_Tick;
    
        }
    
    
        protected override void OnPaint(PaintEventArgs e)
        {
            if (isMovingR == false)
            {
                e.Graphics.DrawImage(stnd, imageX, imageY);
                //Refresh();
            }
            if (canMoveR == true)
            {
                e.Graphics.DrawImage(animate.Frame2Draw(), imageX, imageY);
                timer.Stop();// this simply stops the animation from continuing once I have stopped press D
            }
    
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            moveRight = Keys.D;
            moveLeft = Keys.A;
    
            if (e.KeyCode == moveRight)
            {
                isMovingR = true;
                //imageX += 5;
       timer.Enabled = true;
                Refresh();
            } else if (e.KeyCode == moveLeft)
            {
                isMovingL = true;
                imageX -= 5;
                Refresh();
            } 
    
        }
