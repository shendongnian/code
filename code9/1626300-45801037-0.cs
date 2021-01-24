        public class Person
        {
            [key] //No need to mention [key] annotation here, Because EF will automatically understand Id property will act as Primary Key.
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
        }
        public class Teacher: Person
        {
           
        }
        public class Student: Person
        {
            public string Code { get; set; }
        }
        public class ExchangeStudent : Student
        {
          
            public string HomeUniversity { get; set; }
        }
