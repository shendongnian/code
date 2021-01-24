    var sum = 0;
    while (true)
            {
               Console.Write("Enter a number:  or ok to exit : ");
                String input = Console.ReadLine();
                if (input == "ok" || input.ToLower() == "ok") break;
                if(string.IsNullOrWhiteSpace(input))
                continue;
                sum += Convert.ToInt32(input);
            }
            Console.WriteLine("Total Result: " + sum);
