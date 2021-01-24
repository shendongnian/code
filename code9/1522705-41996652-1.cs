    String str = "Select(GetName(null),GetID(22),1,GetID(),GetData(\"T\",100),true)";
    Match result = Regex.Match(str, @"^(\w+)\((\w+(\(.*?\))?[\s,]*?)*\)$");
    
    string outerMethodName = result.Groups[1].Value;
    List<string> arguments = result.Groups[2].Captures.Cast<Capture>().Select(i => i.Value.TrimEnd(',')).ToList();
    
    Console.WriteLine(outerMethodName);
    
    int argumentLength = arguments.Count;
    foreach (string argument in arguments)
    {
        Console.WriteLine(argument);
    }
