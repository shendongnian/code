    {
            List<string> Num = new List<string>();
            Console.WriteLine("Enter 5 numbers");
            for (int i = 0; 5 > i; i++)
            {
                Console.Write((i + 1) + ". ");
                Num.Add(Console.ReadLine());
            }
            Num.Sort();
            Console.Write("Sorted numbers: ");
            foreach (string value in Num)
            {
                Console.Write(value + " ");
            }
            Console.ReadLine();
            List<string> odd = new List<string>();
            List<string> even = new List<string>();
            foreach (var value in Num)
            {
                if (Int32.Parse(value) % 2 != 0)
                {
                    odd.Add(value);
                }
                else
                {
                    even.Add(value);
                }
            }
            Console.Write("Odd numbers: ");
            foreach (string number in odd)
            {
                Console.Write(number + " ");
            }
            Console.Write("Even numbers: ");
            foreach (string numbers in even)
            {
                Console.Write(numbers + " ");
            }
            Console.ReadLine();
        }
