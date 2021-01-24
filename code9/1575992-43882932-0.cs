    var description = "\"AAC\",\"AAC Holdings, Inc.\"";
    var listText = description.Split(new[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
    foreach (var s in listText)
    {
        Console.WriteLine(s.Replace("\"",""));
    }
    Console.ReadLine();
