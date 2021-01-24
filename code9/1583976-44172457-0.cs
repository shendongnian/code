    private List<Student> students = new List<Student>();
    private void insert(string StudentNumber, string StudentName, string UnitNumber, string UnitName, string Mark, string combobox)
    {
       Student s = new Student
       {
         StudentNumber =StudentNumber,
         StudentName =StudentName,
         UnitNumber =UnitNumber
         UnitName =UnitName,
         Mark = Mark
         Combobox = combobox
       };
      students.Add(s);
    }
    public class Student
    {
      public string StudentNumber{get; set;}
      public string StudentName {get; set;}
      public string UnitNumber {get; set;}
      public string UnitName {get; set;}
      public string Mark {get; set;}
      public string Combobox {get;set;}
    }
