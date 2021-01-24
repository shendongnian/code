     namespace dt{
        class Averager
            static void Main(){
      var total = 0.0;
      int runningNumbers = 0;
      while(true) 
      {
        Console.Write("Enter a number or type \"done\" to see the average: ");
        var test = Console.Readline();
        if(test.ToLower() == "done") 
        {
          var average = (total / runningNumbers);
          Console.Write("Average: " + average);
          break;
        }
        else 
        {
          double tempNew = Convert.toDouble(test);
          total += tempNew;
          runningNumbers += 1;
          continue;
        }
       }
      }
     }
    }
