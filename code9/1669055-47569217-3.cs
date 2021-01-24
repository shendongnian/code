    const string MathCourseName = "Math";
    var Student1 = new Student("Alice");
    Student1.Infos.Add(new Info(MathCourseName, 4));
    
    var Student2 = new Student("Bob");
    Student2.Infos.Add(new Info(MathCourseName, 2));
    
    var studentsByName = new Dictionary<string, Student> {
        {Student1.Name, Student1 },
        {Student2.Name, Student2 },
    };
