    //Prep work/data structures
    var students = new SortedDictionary<string, List<string>>();
    Action<string, string> AddStudentTask = (student, taskDate) => {
        if (!students.ContainsKey(student))
            students.Add(student, new List<string>());
        students[student].Add(taskDate);
    };
    //Read existing data
    string readrecord = @"C:\classes\tasks\taskrecord.txt";
    var lines = File.ReadLines(readrecord).Select(l => l.Split(','));
    foreach (var line in lines)
    {
        AddStudentTask(line[1], line[0]);
        AddStudentTask(line[2], line[0]);
        AddStudentTask(line[3], line[0]);
        AddStudentTask(line[4], line[0]);
        AddStudentTask(line[5], line[0]);
        AddStudentTask(line[6], line[0]);
    }
    //Write new data
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
