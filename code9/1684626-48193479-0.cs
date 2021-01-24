    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Room> Rooms { get; set; }
    }
    
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }
    }
