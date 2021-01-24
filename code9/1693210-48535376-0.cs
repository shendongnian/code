    List<string> data = new List<string>() { "Delphi", "dot net", "java", "Oracle" }
    String line = "Dheeraj has experience in dot net java programming Oracle javascript and Delphi";
    
    foreach (var item in line.Split(new char[] { ' ' }))
    {
        // If you use Contains here, it will use sorting and searching the keyword
        if(data.Contains(item))
        {
            Console.WriteLine(item);
        }
    }
