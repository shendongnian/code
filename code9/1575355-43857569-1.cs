    public void GetWords(string path) 
    {
        if (File.Exists(path))
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("Directory not correct");
        }
    }
