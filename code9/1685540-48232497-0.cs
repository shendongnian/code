    public void ForEachCommaSeperatedItemIn(string s, Action<string> f)
    {
        string[] array = s.Split(',');
        foreach (string s in array)
        {
            f(x);
        }
    }
