        int count = 0;
        double sum = 0.0;
        while (true)
        {
            Console.WriteLine("Enter a number or type \"done\" to see the average: ");
            var input = Console.ReadLine();
 
            if (input == "done") 
            {
                Console.WriteLine(sum / count);
                break;
            }
            try
            {
                sum += double.Parse(input);
                count += 1;
            }
            catch (FormatException)
            {
                Console.WriteLine("That is not valid input.");
            }
      }
