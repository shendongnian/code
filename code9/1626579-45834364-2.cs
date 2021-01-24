    namespace BusinessObject
    {
        public abstract class Person
        {
            public string Name { get; set; }
        }
        
        public class Student
        {
            public int StudentId { get; set; }
            public string Nickname { get; set; }
        }
        
        //ExchangeStudent derives from Student
        public class ExchangeStudent : Student
        {
            public int ExchangeStudentId { get; set; }
            public string HomeUniversity { get; set; }
        }
    }
