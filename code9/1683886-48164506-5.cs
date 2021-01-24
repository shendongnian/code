    static void Main(string[] args)
        {
            var student = new Student
            {
                Id=1,
                Name="Simple Code",
                Courses=new List<Course> {
                    new Course{ Id=1, Name="history", Teacher=new Person{Id=1,Name="James",BOD=DateTime.UtcNow,Salary=1000.50M } },
                    new Course{ Id=2, Name="Math", Teacher=new Person{Id=2,Name="David",BOD=DateTime.UtcNow,Salary=6000.50M } }
                }
            };
            var jsonResolver = new PropertyIncludeSerializerContractResolver();
            jsonResolver.IncludeProperty(typeof(Student), "Courses");
            // if you want Teacher property to get serialized uncomment this code
            //jsonResolver.IncludeProperty(typeof(Course), "Teacher");
            var jsonStr = student.ToJson(jsonResolver);
            Console.WriteLine(jsonStr);
            Console.ReadLine();
        }
