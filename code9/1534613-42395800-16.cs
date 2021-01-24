    public class UseCase
    {
        public string Name { get; set; }
        public Point MyPoint { get; set; }
        public Rectangle Field { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public UseCase()
        {
            MyPoint = new Point();
            Field = new Rectangle();
        }      
    }
