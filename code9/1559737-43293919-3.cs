        // since you want to aggregate within the loop, you have to declare sum 
        // without the loop  
        double sum = 0.0;
        while (true)
        {
            //DONE: You're summing up, right? It'll be sum, not average
            Console.WriteLine("Enter a number or type \"done\" to see the sum: ");
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
