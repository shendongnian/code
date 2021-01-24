    static void Main()
    {
     int x = 0;
     Console.Write("\nHow many stocks to enter price for:\t"); 
     int size = int.Parse(Console.ReadLine());
     double[] arr = new double[size]; 
     for (int i = 0; i < size; i++)
     {
      Console.Write($"\nEnter price for stock #{++x}: \t");
      arr[i] = Convert.ToDouble(Console.ReadLine()); //Storing value in an array
     }
     Console.WriteLine($"\r\nAverage Price: {arr.Average()} out of {arr.Count()} stocks");
     Console.WriteLine($"Minimum Price: {arr.Min()}");
     Console.WriteLine($"Number of stocks priced between 1.5-35: 
                        {arr.Where(v => v >= 1.5 && v < 35).Count()}");
     Console.ReadLine();
    }
