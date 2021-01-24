    public enum GenderType
    {
       Male, Female, Unknown
    }
    
    public class Person
    {
       public string State {get;set;}
       public GenderType Gender {get;set;}
       public bool Married {get; set}
       public bool SalaryUnderHundredDollar {get;set}
    }
