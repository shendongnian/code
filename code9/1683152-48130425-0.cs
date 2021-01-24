    static void Main()
        {
            int inputCount = 0;
            double total = 0;
            double _num1 = 0;
            double average = 0;
            while (true)
            {
                Console.Write("Please enter a number or type done to see an  average: ");
     
                string num1 = Console.ReadLine();
                if (double.TryParse(num1, out _num1))
                {
                    inputCount++;
                    total += _num1;
                    Console.WriteLine("Total is " + total);
                    average = total / inputCount;
                }
                else if(num1.ToLower() == "done")
                {
                    Console.WriteLine("Average:  " + average);
                    break;
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                    break;
                }
            }
        }
