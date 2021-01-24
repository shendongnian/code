    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
    }
    public class Student : Person
    {
        public Student()
        {
            Friends=new List<Person>();
        }
        public virtual List<Person> Friends { get; set; }
        public int StudentAge { get; set; }
    }
    public class Worker : Person
    {
        public decimal WorkerSalary { get; set; }
    }
