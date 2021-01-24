    namespace World
    {
        public class Human
        {
            // Personal traits
            public string FirstName {get; set;} 
            public string LastName {get; set;} 
            public string FullName => $"{FirstName} {LastName}"; // C#7 notation notation
        }
    }
