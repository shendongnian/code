    public class EnumerableClass
    {
        public int X { get; set; }
        public int Y { get; set; }
        public String A { get; set; }
        public String B { get; set; }
        public String C { get; set; }
        public String D { get; set; }
        public String E { get; set; }
        public Frame F { get; set; }
        public Gatorade Gatorade { get; set; }
        public Home Home { get; set; }
    }
    public class Home
    {
        private Home(int rooms, double bathrooms, Stove stove, InternetConnection internetConnection)
        {
            Rooms = rooms;
            Bathrooms = (decimal) bathrooms;
            StoveType = stove;
            Internet = internetConnection;
        }
        public int Rooms { get; set; }
        public decimal Bathrooms { get; set; }
        public Stove StoveType { get; set; }
        public InternetConnection Internet { get; set; }
        public static Home GetUnitOfHome()
        {
            return new Home(5, 2.5, Stove.Gas, InternetConnection.Att);
        }
    }
    public enum InternetConnection
    {
        Comcast = 0,
        Verizon = 1,
        Att = 2,
        Google = 3
    }
    public enum Stove
    {
        Gas = 0,
        Electric = 1,
        Induction = 2
    }
    public class Gatorade
    {
        private Gatorade(int volume, Color liquidColor, int bottleSize)
        {
            Volume = volume;
            LiquidColor = liquidColor;
            BottleSize = bottleSize;
        }
        public int Volume { get; set; }
        public Color LiquidColor { get; set; }
        public int BottleSize { get; set; }
        public static Gatorade GetGatoradeBottle()
        {
            return new Gatorade(100, Color.Orange, 150);
        }
    }
    public class Frame
    {
        public int X { get; set; }
        public int Y { get; set; }
        private Frame(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Frame GetFrame()
        {
            return new Frame(5, 10);
        }
    }
