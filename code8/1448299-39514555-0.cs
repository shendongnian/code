    public class Person
    {
     public int Id{get;set;}
     public string firstname{get;set;}
     public string lastname{get;set;}
     [NotMapped]
     public string FullName => firstname + " " + lastname;
    }
