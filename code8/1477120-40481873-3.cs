    public class Standard
    {
        public int StandardId { get; set; }
    
        // reference to the name of another navigation property in class Student
        [InverseProperty("CurrentStandard")]
        public ICollection<Student> CurrentStudents { get; set; }
        
        // reference to the name of another navigation property in class Student
        [InverseProperty("PreviousStandard")]
        public ICollection<Student> PreviousStudents { get; set; }   
    }
