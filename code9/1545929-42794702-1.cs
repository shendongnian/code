    Dictionary<string, string> data = new Dictionary<string, string>();
    using(StreamReader reader = new StreamReader("C:/YourFilePath.txt"))
    {    
       while (reader.Peek() >= 0)
       {
            string[] line = reader.ReadLine().Split('=');
            data.Add(line[0].TrimEnd(), line[1].TrimStart());
       }
    }
