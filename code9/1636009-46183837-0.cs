    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Test.txt");
                
    using (var fs = new StreamWriter(path))
    {
        fs.Write("Hi there!");
    }
                
    Console.WriteLine("Message Saved");
