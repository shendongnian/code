    public class PersonBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class Person : PersonBase
    {
        public string OtherProperty { get; set; }
    }
