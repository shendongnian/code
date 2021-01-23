    public class Person
    {
        public string Name { set; get; } // property with auto setter and getter
        public string Address { set; get; } // property with auto setter and getter
    
       public Person(string givenName, string givenAddress)
       {
            Name = givenName;
            Address = givenAddress;
       }
    }
