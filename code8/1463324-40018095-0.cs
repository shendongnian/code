            char operation;
            String calculation;
            double num1, num2, ans;
            Console.WriteLine("Place your calculation in the form (x'symbol'y)");
            calculation = Console.ReadLine();
            Regex testRegex = new Regex(@"([0-9]*)([+-/*])([0-9]*)");
            var match = testRegex.Match(calculation);
            
            if (!match.Success)
            {
                Console.WriteLine("Invalid syntax");
                return;
            }
            num1 = double.Parse(match.Groups[1].Value);
            num2 = double.Parse(match.Groups[3].Value);
            operation = match.Groups[2].Value[0];
            switch (operation)
            {
                case '+':
                    ans = num1 + num2;
                    Console.WriteLine(num1 + num2);
                    break;
                case '-':
                    ans = num1 - num2;
                    Console.WriteLine(num1 - num2);
                    break;
                case '/':
                    ans = num1 / num2;
                    Console.WriteLine(num1 / num2);
                    break;
                case '*':
                    ans = num1 * num2;
                    Console.WriteLine(num1 * num2);
                    break;
            }
