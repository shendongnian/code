    private void Timer_Tick(object sender, EventArgs e)
    {
        double velocity = /*(speed: pixels per seconds)*/ 100 * /*(timer tick time in seconds)*/ 0.003;
        int posX = Box.Location.X;
        int posY = Box.Location.Y;
        if (Keyboard.IsKeyDown(Keys.Up)
        {
            posY -= velocity;
        }
        else if (Keyboard.IsKeyDown(Keys.Down)
        {
            posY += velocity;
        }
        //Also, don't put else here, so you can go diagonally.
        if (Keyboard.IsKeyDown(Keys.Left)
        {
            posX -= velocity;
        }
        else if (Keyboard.IsKeyDown(Keys.Right)
        {
            posX += velocity;
        }
        
        Box.Location = new Point(posX, posY);
        labelPosX.Text = posX.ToString(); //Testing purposes
        labelPosY.Text = posY.ToString(); //Testing purposes
    }
