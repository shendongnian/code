        var sum = 0;
        while (true)
        {
            Console.Write("Enter a number (or 'ok' to exit): ");
            var input = Console.ReadLine();
            int newVariable = 0;
            if (input.ToLower() != "ok")
            {
                newVariable = Convert.ToInt32(input);
            }
            input = Console.ReadLine();
            if (input.ToLower() == "ok"){
                break;
            sum += newVariable;
            }
        }
        Console.WriteLine("Sum of all numbers is: " + sum);
