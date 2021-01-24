    StreamReader sr = new StreamReader("../../file.txt");
    string line;
    while((line = sr.ReadLine()) != null)
    {
        string[] words = line.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i].TrimEnd('.');
            if (word.EndsWith("ec"))
            {
                words[i] = word;
            }
        }
    }
