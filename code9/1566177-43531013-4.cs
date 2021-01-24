    public class Report
    {
       public string ReportName {get; set;};
       public string TestReport {get; set;};
       public List<Person> Results {get; set;}
    }
    public class Person
    {
       public string Name {get; set};
       public string LastName {get; set};
       public int ID {get; set;}
    }
