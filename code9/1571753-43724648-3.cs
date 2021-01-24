    public static void Main(string[] args) {
      for (int n = Convert.ToInt32(Console.ReadLine()); // start with user input
           n > 1;                                       // safier choice then n != 1
           n = n % 2 == 0 ? n / 2 : 3 * n + 1)          // next step either n/2 or 3*n + 1 
        Console.WriteLine(n);
    
      Console.ReadKey();
    }
