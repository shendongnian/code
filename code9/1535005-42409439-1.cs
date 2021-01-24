    public class PersonalPerson
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
    
    public class Person
    {
        public string i_date { get; set; }
        public string i_location { get; set; }
        public string i_summary { get; set; }
        public List<PersonalPerson> people { get; set; }
    }
    
    public class RootObject
    {
        public Person person { get; set; }
    }
