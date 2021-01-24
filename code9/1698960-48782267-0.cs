                ArrayList Num = new ArrayList();
    
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
    
                ArrayList odd = new ArrayList();
                ArrayList even = new ArrayList();
                int V;
                foreach (string value in Num)
                {
                    V = int.Parse(value);
                    if (V % 2 != 0)
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
    
    
      [1]: https://i.stack.imgur.com/LrGhf.
