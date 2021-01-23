    // test array 
    int[] array = Enumerable.Range(1, 100).ToArray();
    int stepsize = 3;
    for (int i = 0; i < array.Length; i += stepsize)
    {
        string s = String.Join(" ", array.Skip(i).Take(stepsize));
        Console.WriteLine(s);
    }
