    public class Human
    {
        // Personal traits
        public string FirstName {get;set;} 
        public string LastName {get;set;} 
        public string FullName => first_name + " " + last_name; // C#7 notation
    }
}
