    public class Room{
        public int Available { get; set;}
        public int Price { get; set; }
        public bool availability { get; set; }
    }
    public class Hotel{
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
