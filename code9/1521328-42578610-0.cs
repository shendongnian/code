     public int DoSomeCalculation()
     {
       int a=0;
       try
       {
         //perform some calculation
         return a;
       }
       catch(Exception ex)
       {
        return -1;
       }
       finally
       {
       Console.WriteLine("Some cleanup");
       }
      }
