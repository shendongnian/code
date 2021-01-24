    static void Main()
    {
        var knownOperators = new[] { '+', '-', '*', '/' };
        // Get input string from user
        Console.Write("Please input a math string: ");
        string inputNumber = Console.ReadLine(); // "190+154+114";
        // Get all the numbers by splitting on the operators
        double tmp = 0;
        var numbers = inputNumber
            .Split(knownOperators, StringSplitOptions.RemoveEmptyEntries)
            .Where(num => double.TryParse(num, out tmp))
            .Select(n => tmp)
            .ToList();
        // Get all the operators by going through the string again
        var operators = new List<char>();
        foreach(var character in inputNumber)
        {
            if (knownOperators.Contains(character)) operators.Add(character);
        }
        // Validate we have one more number than operator
        if (numbers.Count < (operators.Count + 1))
        {
            Console.WriteLine("Error: there were too many operators!");
        }
        else if (numbers.Count > (operators.Count + 1))
        {
            Console.WriteLine("Error: there were too many numbers!");
        }
        else
        {
            // Do the math!
            double result = numbers[0];
            for(int i = 1; i < numbers.Count; i++)
            {
                switch (operators[i - 1])
                {
                    case '+':
                        result += numbers[i];
                        break;
                    case '-':
                        result -= numbers[i];
                        break;
                    case '*':
                        result *= numbers[i];
                        break;
                    case '/':
                        result /= numbers[i];
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("The result is: {0}", result);
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
