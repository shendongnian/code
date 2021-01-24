    string[] specialCharsToRemove = new [] { "[", "]", "(", ")", "'", "," };
    using (var reader = new StreamReader ("C://Users//HP//Documents//result2.txt")) 
    {
        string line = reader.ReadToEnd();
        foreach(string s in specialCharsToRemove)
        {
            line = line.Replace(s, "");
        } 
        Message1.text = res;            
    }
