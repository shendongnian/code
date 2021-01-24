    public class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsWall { get; set; }
        public GameObject(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public class Wall : GameObject
    {
        public Wall(int x, int y) : base(x,y)
        {
            IsWall = true;
        }
    }
