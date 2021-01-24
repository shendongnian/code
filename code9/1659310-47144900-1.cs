    public class Student
    { 
      public int Id {get; set;}
      public string Name {get; set; }
     
      public Student(object o) 
      {
        Student student = o as Student;
        if (student != null)
        {
           Id = student.Id;
           Name = student.Name;
        }
         
        // other cases to build a User copy
        string json = o as string;
        if (json != null) 
        {
             Student student = JsonConvert.Deserialize<Student>(json);
             Id = student.Id;
             Name = student.Name;
        }
         
      }
      public Student() 
          : this(null)
      {
      }
     
      public Student(int id, string name) 
          this(null)
      {
          Id = id;
          Name = name;
      }
    }
   
    static void Main(string[] args) 
    {
         Student student = new Student(7634, "Jim");
            
         // build a copy
         Student copy = new Student(student);
    }
