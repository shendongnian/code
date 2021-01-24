    static string ReadAllLinesWithPeek(StreamReader sr)
    {
        string input = "";
        while (sr.Peek() >= 0)
        {
            input += sr.ReadLine();
        }
        sr.Close();
        return input;
    }
