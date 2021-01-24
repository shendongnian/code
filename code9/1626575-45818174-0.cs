    public class Person
    {
        public int Id {get; set;
        public string Name { get; set; }
        public string LastName { get; set; }
    }
    public class Student : Person
    {
        // the primary key is in the base class
        public string code_s { get; set; }
        public virtual ICollection<Course> courses { get; set; }
    }
    public class ExchangeStudent : Student
    {
        // the primary key is in one of the base classes
        public string HomeUniversity {get; set;}
    }
