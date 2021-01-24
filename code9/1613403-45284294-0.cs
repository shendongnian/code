    public class Person
    {
     public int Id {get; set;}
     public DateTime Birth {get; set;}
    }
    
    public class Details 
    {
     public int Id {get; set;}
     public int PerId {get; set;}
     public Person Person {get; set;}
    }
