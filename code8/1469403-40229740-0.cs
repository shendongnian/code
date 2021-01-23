    static void Main(string[] args)
            {
                int integerNumber;
                double doubleNumber;
                var stuff = Console.ReadLine();
                bool isInteger = int.TryParse(stuff, out integerNumber);
                bool isDouble = double.TryParse(stuff, out doubleNumber);
                if(isInteger)
                    Console.WriteLine(integerNumber.GetType() + stuff);
                else if(isDouble)
                    Console.WriteLine(doubleNumber.GetType() + stuff);
                else
                {
                    Console.WriteLine(stuff.GetType() + stuff );
                }
                Console.ReadLine();
            }
