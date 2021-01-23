    namespace XamDataGridDemo
    {
        public class Person
        {
            public int Id { get; set; }
    
            public string FirstName { get; set; }
    
            public string LastName { get; set; }
    
            public int Age { get; set; }
    
            public override string ToString()
            {
                return $"{LastName}, {FirstName} ({Age})";
            }
        }
    }
