    public IEnumerable<String> GetWords(string path) 
    {
        if (File.Exists(path))
        {
            return File.ReadAllLines(path); //.AsEnumerable();
        }
        else
        {
            Console.WriteLine("Directory not correct");
        }
    }
