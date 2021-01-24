    while (true)
            {
                Console.WriteLine("write numbers seperated with coma");
                List<int> numbers = new List<int>();
                var input = (Console.ReadLine());
                var values = input.Split(',');
                foreach (var value in values)
                {
                    int number;
                    // If the input can be parsed to int, add it to numbers list.
                    if (int.TryParse(value, out number))
                    {
                        numbers.Add(number);
                    }
                }
                if (numbers.Count < 5)
                {
                    Console.WriteLine("invalid list!! retry");
                    continue;
                }
                else
                {
                    numbers.Sort();
                    numbers.ForEach(number => Console.WriteLine(number));
                }
            }
