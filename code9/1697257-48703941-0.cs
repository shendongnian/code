     public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
            
        //Foreign key for Standard
        public int StandardId { get; set; }
        public Standard Standard { get; set; }
    }
    
    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        
        public ICollection<Student> Students { get; set; }
    }
