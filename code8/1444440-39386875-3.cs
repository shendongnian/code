    class RangePrinter
    {
       /* Injecting the Write target is skipped for simplicity */
       
       public void PrintRange(int lowerBound, int upperBound)
       {
          for(int i = lowerBound; i < upperBound; i++)
          {
             Console.WriteLine(i);
          }
       }
    }
