    public class User
    {
        [Key]
        public int UserId {get; set;}
        public string Username {get; set;}
        public virtual List<Room> OwnerOfRooms {get; set;}
        public virtual List<Room> MemberOfRooms {get; set;}
    }
