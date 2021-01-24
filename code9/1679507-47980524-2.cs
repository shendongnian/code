    double posX, posY;
    private void Timer_Tick(object sender, EventArgs e)
    {
        double velocity = /*(speed: pixels per seconds)*/ 100 * /*(timer tick time in seconds)*/ 0.003;
        if (Keyboard.IsKeyDown(Keys.Up))
        {
            posY -= velocity;
        }
        else if (Keyboard.IsKeyDown(Keys.Down))
        {
            posY += velocity;
        }
        //Also, don't put else here, so you can go diagonally.
        if (Keyboard.IsKeyDown(Keys.Left))
        {
            posX -= velocity;
        }
        else if (Keyboard.IsKeyDown(Keys.Right))
        {
            posX += velocity;
        }
        Box.Location = new Point((int)posX, (int)posY);
        labelPosX.Text = posX.ToString(); //Testing purposes
        labelPosY.Text = posY.ToString(); //Testing purposes
    }
    public static class Keyboard
    {
        private static readonly HashSet<Keys> keys = new HashSet<Keys>();
        public static void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (keys.Contains(e.KeyCode) == false)
            {
                keys.Add(e.KeyCode);
            }
        }
        public static void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (keys.Contains(e.KeyCode))
            {
                keys.Remove(e.KeyCode);
            }
        }
        public static bool IsKeyDown(Keys key)
        {
            return keys.Contains(key);
        }
    }
