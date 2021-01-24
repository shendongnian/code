    interface IPerson
    {
        DateTime JoinDate { get; set; }
        // more common properties or methods
    }
    public class Teacher : IPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public int Age { get; set; }    
    }
       
    public class Student : IPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public string Lesson { get; set; }   
    }
    
    public class Parent : IPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public string StudentName { get; set; }
    
        public string Job { get; set; }    
    }
