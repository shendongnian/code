        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var words = line.Split(' ');
                foreach (var word in words)
                {
                    if (word.StartsWith(toFind))
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Directory not found");
        }
