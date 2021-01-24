    string s = "Test";
    foreach (char a in s)
    {
        if (a > 127)
        {
            throw new Exception(string.Format("{0} is not ASCII!", a));
        }
        Console.WriteLine("{0}: {1}", a, (int)a);
    }
