    public class Student
      {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public List<StudentTestScore> Scores { get; set; }
      }
    
      public class StudentTestScore
      {
        public int StudentID { get; set; }
        public int Score { get; set; }
      }
    
      class Program
      {
    
        static void Main(string[] args)
        {
          var students = new List<Student>
            {
            new Student { StudentID = 1, FirstName = "Brett", LastName = "X" },
            new Student { StudentID = 2, FirstName = "John", LastName = "X" }
            };
          var grades = new List<StudentTestScore> { new StudentTestScore { StudentID = 1, Score = 98 } };
    
          var combined = students.Join(grades, x => x.StudentID, y => y.StudentID,
                    (x, y) => new
                    {
                      Student = $"{x.FirstName} {x.LastName}",
                      Grade = y.Score
                    }).ToList();
    
          combined.ForEach(x => Console.WriteLine($"{x.Student} {x.Grade}"));
    
          Console.ReadLine();
        }
