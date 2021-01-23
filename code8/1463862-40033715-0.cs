    static void Main(string[] args)
            {
                List<int> inputs = new List<int>();
                Console.WriteLine("How many grade level classes are you taking?");
                int standardNumber = int.Parse(Console.ReadLine());
                inputs.Add(standardNumber);
                Console.WriteLine();
                Console.WriteLine("How many honors level classes are you taking?");
                int honorsNumber = int.Parse(Console.ReadLine());
                inputs.Add(honorsNumber);
                Console.WriteLine();
                Console.WriteLine("How many AP level classes are you taking?");
                int apNumber = int.Parse(Console.ReadLine());
                inputs.Add(apNumber);
                Console.WriteLine();
                Console.WriteLine("Enter your letter grades when prompted.");
                Console.WriteLine("=======================================");
                for (int i = 0; i < inputs.Count; i++)
                {                
                    Console.WriteLine("Enter letter grade for honors class {0}:", inputs[i]);
                    switch (i)
                    {
                        case 1:
                            string class1 = Console.ReadLine();
                            break;
                        case 2:
                            string class2 = Console.ReadLine();
                            break;
                        case 3:
                            string class3 = Console.ReadLine();
                            break;
                        case 4:
                            string class4 = Console.ReadLine();
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine();
                }
                Console.Read();
            }
