    static void Main(string[] args)
    {
      Console.Write("Enter a maximum number for the Fibonacci sequence: ");
      Console.WriteLine(Fibonacci(Convert.ToInt32(Console.ReadLine())));
      Console.WriteLine("Press any key to quit.");
      Console.ReadKey();
    }
    static string Fibonacci(int max)
    {
      int i = 0;
      StringBuilder result = new StringBuilder();
      for (int j = 1; j <= max; j += i)
      {
        result.Append(string.Format("{0} {1} ", i, j));
        i += j;
      }
      if (i <= max)
        result.Append(i);
      return result.ToString();
    }
