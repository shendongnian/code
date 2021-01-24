        public abstract class Student : Person
        {
            [Key]public int Id_student { get; set; }        
        }
    
        public class LocalStudent : Student{
    
        }
        
        public class ExchangeStudent : Student
        {        
            public string HomeUniversity {get; set;}
        }
