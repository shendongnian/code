    public class Student : IEntity<int>
    {
         public int Id { get; set; }
         public string Name { get; set; }
    }
    
    public class Course : IEntity<int>
    {
         public int Id { get; set; }
         public string Name { get; set; }
         public IEnumerable<Student> Students { get; set; }
    }
