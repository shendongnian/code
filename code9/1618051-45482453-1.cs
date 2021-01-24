    var lineParser = new Regex("^(?<kind>Teacher|Class|)\\s*(?<name>[^$]+)");
    var lines = input.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        .Select(line =>
        {
            var match = lineParser.Match(line);
            var kind = match.Groups["kind"].Value;
            var name = match.Groups["name"].Value;
            return new { kind, name };
        });
    var teachers = new List<Teacher>();
    foreach (var line in lines)
    {
        if (line.kind == "Teacher")
            teachers.Add(new Teacher {Name = line.name});
        else if (line.kind == "Class")
            teachers.Last().Classes.Add(new Class {Name = line.name});
        else
            teachers.Last().Classes.Last().Students.Add(new Student {Name = line.name});
    }
