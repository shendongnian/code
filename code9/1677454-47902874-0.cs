    using (var sr = File.OpenText(path))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains("localhost"))
            {
                Console.WriteLine(line);
            }
        }
    }
