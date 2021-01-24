          int output = 0;
          Console.Write("Input : ");
          string input = Console.ReadLine();
          string[] inputArray = input.Split(' ');
          foreach (string eachInputValue in inputArray)
          {
             output += int.Parse(eachInputValue);
          }
          Console.Write("Output : " + output);
          Console.ReadKey();
