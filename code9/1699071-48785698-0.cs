    static void ConcatenateWithOperator()
    {
        string txt = string.Empty;
        for (int i = 0; i < 1000; i++)
        {
            txt += new string('x', i);
        }
    }
    static void ConcatenateWithStringBuilder()
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < 1000; i++)
        {
            builder.Append(new string('x', i));
        }
        string result = builder.ToString();
    }
    static void ConcatenateWithConcat()
    {
        string txt = string.Empty;
        for (int i = 0; i < 1000; i++)
        {
            txt = string.Concat(txt, new string('x', i));
        }
    }
    static void ConcatenateWithOperator2()
    {
        for (int i = 0; i < 1000; i++)
        {
            string result = new string('x', i) + new string('x', i);
        }
    }
    static void ConcatenateWithStringBuilder2()
    {
        for (int i = 0; i < 1000; i++)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(new string('x', i));
            builder.Append(new string('x', i));
            string result = builder.ToString();
        }
    }
        DateTime start1 = DateTime.Now;
        ConcatenateWithOperator();
        Console.WriteLine((DateTime.Now - start1).TotalSeconds);
        DateTime start2 = DateTime.Now;
        ConcatenateWithStringBuilder();
        Console.WriteLine((DateTime.Now - start2).TotalSeconds);
        DateTime start3 = DateTime.Now;
        ConcatenateWithConcat();
        Console.WriteLine((DateTime.Now - start3).TotalSeconds);
        DateTime start4 = DateTime.Now;
        ConcatenateWithOperator2();
        Console.WriteLine((DateTime.Now - start4).TotalSeconds);
        DateTime start5 = DateTime.Now;
        ConcatenateWithStringBuilder2();
        Console.WriteLine((DateTime.Now - start5).TotalSeconds);
