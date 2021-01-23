    public class Student
    {
        public int StudentID { get; set; }
        
        public Standard CurrentStandard { get; set; }
        public Standard PreviousStandard { get; set; }
    }
    public class Standard
    {    
        public int StandardId { get; set; }
    
        public ICollection<Student> CurrentStudents { get; set; }
        public ICollection<Student> PreviousStudents { get; set; }   
    }
