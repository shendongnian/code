    static void Main()
    {
        var knownOperators = new[] { '+', '-', '*', '/' };
        // Get input string from user
        Console.Write("Please input a math string: ");
        string inputNumber = Console.ReadLine(); // "190+154+114";
        var numbers = new List<double>();
        var operators = new List<char>();
        double tmp = 0;
        // We will break up the string by searching for operators. Each time we find
        // one, we grab the string from the previous operator to the current one and
        // store it in 'numbers' as a double, then we grab the current operator and
        // store it in 'operators' as a char. At the very end, we grab the last number.
        var previousOperatorIndex = 0;
        var operatorIndex = inputNumber.IndexOfAny(knownOperators, previousOperatorIndex);
        while (operatorIndex > -1)
        {
            // Add the number part - the string from the previous operator to this one
            if (double.TryParse(inputNumber.Substring(previousOperatorIndex, 
                operatorIndex - previousOperatorIndex), out tmp))
            {
                numbers.Add(tmp);
            }
            operators.Add(inputNumber[operatorIndex]);
            previousOperatorIndex = operatorIndex + 1;
            operatorIndex = inputNumber.IndexOfAny(knownOperators, previousOperatorIndex);
        }
        // Add the last number (after the last operator)
        if (double.TryParse(inputNumber.Substring(previousOperatorIndex), out tmp))
        {
            numbers.Add(tmp);
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
            for (int i = 1; i < numbers.Count; i++)
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
