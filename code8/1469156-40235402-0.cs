    public abstract class Tile
    {
        private Point direction;
    
        public Point Direction
        {
          get { return direction; }
          set { direction = value; }
        }
        public abstract string someFunction();
    }
