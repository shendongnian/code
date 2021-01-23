    private static Random gen = new Random();    
    ...
    var result = new List<string>() {"A", "B", "C", "D"}
      .RandomItemNoReplacement(gen)
      .Take(10);
    // D, C, B, A, C, A, B, D, A, C (seed == 123)  
    Console.Write(string.Join(", ", result));
