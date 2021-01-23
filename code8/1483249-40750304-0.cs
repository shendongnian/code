    class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    class StudentTestScores {
        public int StudentId { get; set; }
        public int History { get; set; }
        public int Algebra { get; set; }
        public int Geometry { get; set; }
        public int Biology { get; set; }
    }
    static void Main(string[] args) {
        var studentCollection = new List<Student>(new [] {
            new Student() {StudentId = 1, FirstName = "Test", LastName = "Test"}, 
        });
        var testResultCollection = new List<StudentTestScores>(new [] {
            new StudentTestScores() {StudentId = 1, Algebra = 2, Biology = 5, Geometry = 3}, 
        });
        var testResults = from student in studentCollection
                          join testResult in testResultCollection
                            on student.StudentId equals testResult.StudentId
                          select Combine(student, testResult);
        foreach (var item in testResults) {
            Console.WriteLine($"{item.StudentId} {item.FirstName} {item.History} {item.Biology}");
        }
        Console.ReadKey();
    }
    static dynamic Combine(params object[] objects) {
        var exp = (IDictionary<string, object>) new ExpandoObject();
        foreach (var o in objects) {
            foreach (var prop in o.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)) {
                if (prop.CanRead && !exp.ContainsKey(prop.Name)) {
                    exp.Add(prop.Name, prop.GetValue(o));
                }
            }
        }
        return exp;
    }
