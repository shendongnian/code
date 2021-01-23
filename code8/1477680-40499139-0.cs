    public class MyModel
    {
        public int GridX { get; set; }
        public int GridY { get; set; }
        public int GetHashCode()
        {
           unchecked
           {               
               return (GridX.GetHashCode * 397) ^ GridY;
           }
        }
    }
