    using System;
    namespace dt
    {
      class Averager 
      {
        static void Main() 
        {
          var total = 0.0;
          int runningNumbers = 0;
          while(true) 
          {
            Console.Write("Enter a number or type \"done\" to see the average: ");
            string input = Console.ReadLine();
            if(input.ToLower() == "done") 
            {
              var average = (total / runningNumbers);
              Console.Write("Average: " + average);
              break;
            }
            else 
            {
              var tempNew = Double.Parse(input);
              total += tempNew;
              runningNumbers += 1;
              continue;
            }
          }
        }
      }
    }
