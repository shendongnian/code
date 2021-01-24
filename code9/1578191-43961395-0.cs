    public class MyCustomType
    {
       public string Employee {get; set;}
       public string Student {get; set;}
    
       public override string ToString()
       {
          return string.Format("{0} - {1}",Employee, Student);
       }
    }
