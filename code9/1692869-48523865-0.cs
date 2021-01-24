    public class Person
    {
       public string Name { get; set; } 
       public DateTime BirthDateTime { get; set; }
       public object Birth => new {
           Year = BirthDateTime.Year,
           Month = BirthDateTime.Month,
           Day = BirthDateTime.Day,
       };
    }
