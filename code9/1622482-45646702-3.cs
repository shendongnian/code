    foreach (int[] g in list)
    {
        StringBuilder sb = new StringBuilder();
        foreach(int num in g)
        {
            sb.Append(num.ToString());
        }
        Console.WriteLine(sb.ToString());
    }
