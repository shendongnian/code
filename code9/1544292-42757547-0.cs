    public class Contact
    {
        [PrimaryKey, AutoIncrement] //use this so SQLite know this ContactId is the primary key of Contact entity
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        ...
    }
