    Console.WriteLine("enter amount of tries"); // typo
    int TryCount = Convert.ToInt32(Console.ReadLine());
    
    Random numgen = new Random(); 
    Console.Write(Enumerable
      .Range(0, TryCount)
      .Average(x => numgen.Next(1, 6)));
    Console.ReadLine();
