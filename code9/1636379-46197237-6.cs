    int N = 100;
    
    List<int> myList = Enumerable.Range(0, N).ToList();
    
    double K = 53;
    
    List<int> solutions=new List<int>();
    for (int i=1;i<=K;i++)
    {
        solutions.Add(myList[(int)Math.Round(i*(N/K)-1)]);
    }
    Console.WriteLine(solutions.Count);
    Console.WriteLine(string.Join(", ", solutions));
