    public class Actor
    {
        // .... implementation of above properties
        private const int cSIZE = 10;
        public void Draw(Graphics g)
        {
            //implementation of drawing for object
            g.DrawCircle(Brushes.Blue, this.X, this.Y, cSIZE, cSIZE); 
        }
    }
