    static string ReadAllLinesWithPeek(StreamReader sr)
    {
        string input = "";
        while (sr.Peek() >= 0)
        {
            input += (char) sr.Read();
        }
        return input;
    }
