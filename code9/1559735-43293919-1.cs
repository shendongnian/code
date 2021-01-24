        // since you want to aggregate within the loop, you have to delare sum 
        // without the loop  
        double sum = 0.0;
        while (true)
        {
            Console.WriteLine("Enter a number or type \"done\" to see the average: ");
            var input = Console.ReadLine();
 
            if (input == "done") 
            {
                Console.WriteLine(sum);
                break;
            }
            try
            {
                sum += double.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("That is not valid input.");
            }
      }
