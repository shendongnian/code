    string source = null;
    // Keep on asking user to put number until input
    //   1. Has at least one character - source.Any()
    //   2. All characters age digits  - source.All(c => c >= '0' && c <= '9') 
    do {
      Console.WriteLine("Please, input arbitrary non-negative integer number");
      source = Console.ReadLine().Trim();
    }
    while (!(source.Any() && source.All(c => c >= '0' && c <= '9')));
    int[] result = source.Select(c => c - '0').ToArray();
    ...
