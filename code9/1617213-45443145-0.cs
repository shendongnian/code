         using System;
          class Program
           {
             static void Main()
              {
                  // Get ceiling of double value.
           double value1 = 123.456;
        double ceiling1 = Math.Ceiling(value1);
        // Get ceiling of decimal value.
        decimal value2 = 456.789M;
        decimal ceiling2 = Math.Ceiling(value2);
        // Get ceiling of negative value.
        double value3 = -100.5;
        double ceiling3 = Math.Ceiling(value3);
        // Write values.
        Console.WriteLine(value1);
        Console.WriteLine(ceiling1);
        Console.WriteLine(value2);
        Console.WriteLine(ceiling2);
        Console.WriteLine(value3);
        Console.WriteLine(ceiling3);
         }
      }
