    public static void sortInterations()
    {
      Random r = new Random();
      Console.WriteLine("Please enter the number of items in the array that will be sorted:");
      // no checking for invalid input i.e. "aA" will crash here when you try to convert 
      int numitems = Convert.ToInt32(Console.ReadLine());
      int[] arrayOfInts = new int[numitems];
      Console.WriteLine("Please enter a number for iterations:");
      // no checking for invalid input i.e. "aA" will crash here when you try to convert 
      int iterations = Convert.ToInt32(Console.ReadLine());
      // loop for each random array
      for (int index = 0; index < iterations; index++)
      {
        // loop to generate an array of random numbers      
        for (int count = 0; count < arrayOfInts.Length; count++)
        {
          arrayOfInts[count] = r.Next(numitems);
        }
        // a random array has been created start the clock and sort it
        DateTime startTime = DateTime.Now;
        selectionSort(arrayOfInts);
        TimeSpan timeToSort = DateTime.Now - startTime;
        Console.WriteLine("Sort array Number: " + index + " Time for sort to complete in milliseconds: " + timeToSort.TotalMilliseconds);
      }
      Console.ReadLine();
    }
