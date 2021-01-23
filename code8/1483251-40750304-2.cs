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
        Console.WriteLine(JsonConvert.SerializeObject(testResults));
        // outputs [{"StudentId":1,"FirstName":"Test","LastName":"Test","History":0,"Algebra":2,"Geometry":3,"Biology":5}]
        Console.ReadKey();
    }
    static dynamic Combine(params object[] objects) {
        var exp = (IDictionary<string, object>) new ExpandoObject();
        foreach (var o in objects) {
            // note that it's better to cache result of GetProperties call per type, to improve perfomance (GetProperties is relatively slow).
            // or use third party library which can do that for you
            foreach (var prop in o.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)) {
                if (prop.CanRead && !exp.ContainsKey(prop.Name)) {
                    exp.Add(prop.Name, prop.GetValue(o));
                }
            }
        }
        return exp;
    }
