    string path = "file path here";
    
    Dictionary<string, (string Gender, string Weight, string BloodType)> records =
        new Dictionary<string, (string Gender, string Weight, string BloodType)>();
    Stack<string> stack =
        new Stack<string>();
    foreach (string line in File.ReadLines(path))
    {
        if (stack.Count != 1)
        {
            stack.Push(line);
            continue;
        }
       
        string[] fields = 
            line.Split('*');
        records.Add(
            stack.Pop(), 
            (Gender: fields[0], 
             Weight: fields[1], 
             BloodType: fields[2]));
    }
