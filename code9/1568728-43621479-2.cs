    using System;
    
    namespace dt
    {
      class Averager 
      {
        static void Main() 
        {
          var total = 0.0;
          int runningNumbers = 0;
    
          while (true)
            {
                // Ask for user for a new input
                Console.Write("Enter a number or type \"done\" to see the average: ");
                var line = Console.ReadLine();
                // Try to parse the input
                double value;
                if(double.TryParse(line, out value)) {
                    total += value;
                    runningNumbers += 1;
                    continue;
                } else if(line.ToLower() == "done")
                {
                    var average = (total / runningNumbers);
                    Console.Write("Average: " + average);
                    break;
                } else {
                    Console.Write("Invalid input. Please try again.");
                    continue;
                }
            }
        }
      }
    }
