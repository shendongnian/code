    var students = new SortedDictionary<string, List<string>>();
    var AddStudentTask = (student, taskDate) => {
        if (!students.ContainsKey(student))
            students.Add(student, new List<string>());
        students[student].Add(taskDate);
    };
    string readrecord = @"C:\classes\tasks\taskrecord.txt";
    var lines = File.ReadAllLines(readrecord).Select(l => l.Split(','));
    foreach (var line in lines)
    {
        AddStudentTask(line[1], line[0]);
        AddStudentTask(line[2], line[0]);
        AddStudentTask(line[3], line[0]);
        AddStudentTask(line[4], line[0]);
        AddStudentTask(line[5], line[0]);
        AddStudentTask(line[6], line[0]);
    }
    string writeTaskDate = @"C:\classes\tasks\dateRecord.txt";
    using (var sw = new StreamWriter(writeTaskDate))
    {
        foreach (var item in students)
        {
            sw.Write(item.Key);
            sw.Write(",");
            sw.WriteLine(String.Join(",", item.Value));
        }
    }
