    using System;
    
    public class Example
    {
       public static void Main()
       {
          Console.Clear();
    
          DateTime dat = DateTime.Now;
    
          Console.WriteLine("\nToday is {0:d} at {0:T}.", dat);
          Console.Write("\nPress any key to continue... ");
          Console.ReadLine();
       }
    }
