            string inp;
            int location;
            double num1, num2, ans = 0.0;
            string[] ops = { "+", "-", "*", "/" };
            string[] numbers;
            string output;
            Console.WriteLine("Calculator");
            Console.WriteLine("Enter a Calculation.");
            inp = Console.ReadLine();
            if (inp.Contains(ops[0]))
            {
                numbers = inp.Split('+');
                output = "";
                for (int i = 0; i < numbers.Length; i++)
                {
                    ans += Convert.ToDouble(numbers[i]);
                }
               
                Console.WriteLine("{0} = {1}", inp, ans.ToString("0.###"));
                Console.ReadLine();
            }
