    Console.WriteLine("Please enter the month in numerical value (1-        12)");
    if (!Int32.TryParse(Console.ReadLine(), out result))
       {
        result = 0;
       }
        if (result < 1 && result > 12)
         {
           Console.WriteLine("Please close the program, run the program     again, and input  number between 1-12");
          }
