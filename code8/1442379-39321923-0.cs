    public static void bubbleSort(int[] array)
    {
        // start measuring
        DateTime begin = DateTime.Now;
        int start = 0;
        bool swapMade = true;
        
        while (start < array.Length - 1 && swapMade == true) 
        { 
            ...
        }
        // stop measuring
        TimeSpan time = DateTime.Now.Subtract(begin);
        Console.WriteLine(
          "Time for bubblesort to complete: " + time.ToString(@"mm\:ss\.ffffff"));
    }
