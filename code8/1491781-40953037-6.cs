    string[] Results = File1.Split(" ".ToCharArray()).Except(File2.Split(" ".ToCharArray())).OrderByDescending(s => s.Length).Take(10).ToArray();
    for (int i = 0; i < Results.Length; i++)
    {
        Console.WriteLine(Results[i] + " " + Regex.Matches(File1, Results[i]).Count);
    }
