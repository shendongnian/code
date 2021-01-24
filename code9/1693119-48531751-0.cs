    public class Person
    {
        [Index (Value = 0)]
        public long ID {get; set; }
    
        [Index (Value = 1)]
        [Display (Name = "First Name")]
        public string FirstName {get; set; }
    
        [Index (Value = 0)]
        [Display (Name = "Surname")]
        public string Surname {get; set; }
    }
