    public class Student : Person
        {
    
            [Key]public int Id_student { get; set; }
            public string code_s { get; set; }
            public virtual ICollection<Course> courses { get; set; }
            public ExchangeInfo ExchangeInfo{get;set;}
        }
    
        
        public class ExchangeInfo : Student
        {
    
            [Key]public int Id_exchange { get; set; }
            public Student Student{get;set;}
            public string HomeUniversity {get; set;}    
        }
