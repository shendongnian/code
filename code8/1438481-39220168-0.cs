          public class Parent
            {
                public int Id { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
    
                public string Street { get; set; }
                public string HouseNumber { get; set; }
                public string City { get; set; }
    
                public string Email { get; set; }
                public string Mobile { get; set; }
            }
        
            public class Student
            {
                public int Id { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public DateTime Birthday { get; set; }
    
                public int Grade { get; set; }
                public char Class { get; set; }
    
                public string Email { get; set; }
                public string Mobile { get; set; }
            }
    
        public class FormClass  // This is what you suggested but it use other two model
        {
            public Student Student { get; set; }
    
            public Parent Parent { get; set; }
        }
