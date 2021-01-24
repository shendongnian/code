    public static void ReadData()
    {
        char[] sentenceSeparators = {'.', '!', '?'};
        using (StreamReader reader = new StreamReader(dataFile))
        {
            string line = reader.ReadToEnd();
            var split = line.Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var i in split)
            {
                Console.WriteLine(i);
            }
        }
    }
