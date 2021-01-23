    public class Building
    {
        public Building()
        {
            Rooms = new List<Room>();
            NewRoom = new Room();
        }
        public string Button { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "The building name is required.")]
        public string Name { get; set; }
        public Room NewRoom { get; set; }
        public List<Room> Rooms { get; set; }
    }
    public class Room
    {
        //[Required(AllowEmptyStrings = false, ErrorMessage = "The room name is required.")]
        public string RoomName { get; set; }
        public string Area { get; set; }
    }
