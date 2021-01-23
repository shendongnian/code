            char operation;
            string calculation;
            double num1, num2, ans;
            Regex validcheck = new Regex(@"^\d+([+]|[-]|[/]|[*])\d+$");
            Regex findnumber = new Regex(@"\d+");
            Regex findoperation = new Regex(@"([+]|[-]|[/]|[*])");
            Console.WriteLine("Place your calculation in the form (x'symbol'y)");
           
            calculation = Console.ReadLine();
            if (validcheck.IsMatch(calculation))
            {
                num1 = double.Parse(findnumber.Matches(calculation)[0].Value);
                num2 = double.Parse(findnumber.Matches(calculation)[1].Value);
                operation = char.Parse(findoperation.Match(calculation).Value);
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
            }
            else
            {
                Console.WriteLine("The operation you inserted has an invalid format");
            }
            Console.Read();
