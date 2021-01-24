    public class Person{
     public string Name {get;set;}
     public string FirstName{ get;set;}
     public string DisplayName {
        get{
             return Name+","+FirstName;
           }
        
     }
     public string Town{get;set;}
     public int Age {get;set;}
    }
