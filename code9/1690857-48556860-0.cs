    public class Userx
        {
            [Key] //TELL EF TO AUTOGENERATE ID
            public int UserxId { get; set; }
            public int? Access_Level_ID { get; set; } //MAKE ACCESS_LEVEL_ID NULLABLE
            public virtual AccessLevel AccessLevel { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }
