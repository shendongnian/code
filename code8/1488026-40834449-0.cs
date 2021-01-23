    int A;
    do {
      Console.WriteLine("What is number A?");
    }
    while (!int.TryParse(Console.ReadLine(), out A));
