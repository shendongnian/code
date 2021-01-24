    namespace DAO
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
        
        //Use navigation property rather than inheritance to define the relationship
        public class ExchangeStudent 
        {
            public int ExchangeStudentId { get; set; }
            public string HomeUniversity { get; set; }
            public virtual Student Student { get; set; }
        }
    }
