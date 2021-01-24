     public int DoSomeCalculation()
     {
       int a=0;
       try
       {
         //perform some calculations
         return a;
       }
       catch(Exception ex)
       {
        return -1;
       }
       finally
       {
       Console.WriteLine("Do some cleanup");
       }
      }
