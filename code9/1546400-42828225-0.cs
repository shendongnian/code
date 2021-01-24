    public class Registration_class
    {
        [PrimaryKey, AutoIncrement]
        public int Id {get;set;}
        public string name { get; set; }
        public int numOfSeat { get; set; }
        public string password { get; set; }
    }
