    public class Location
    {
        public int Id { get; }
        public int X { get; }
        public int Y { get; }
    }
    public class Building : Location
    {
        public int Stories { get; }
    }
    public class Parking: Location
    {
        public int Capacity { get; }
    }
