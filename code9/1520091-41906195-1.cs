    public class Student
    {
       public Student() {}
    
       public int Name{ get; set; }
       public DateTime Time{ get; set; }
       // other properties
       public string EventId {get;set;}
    
       public virtual Event Event {get; set; }
    }
