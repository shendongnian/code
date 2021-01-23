    bool IsPasswordValid(string pw)
    {
        return pw.Length == 8 && 
                pw.Count(char.IsNumber) == 6 &&
                pw.Count(char.IsLetter) == 2;
    }
