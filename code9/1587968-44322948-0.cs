    switch (mathChoice.ToLower())
                {
                    case "add":
                        Console.WriteLine("What 2 numbers would you like to use?");
                        Console.Write("Number 1 is: ");
                        Num1 = int.Parse(Console.ReadLine());
                        Console.Write("Number 2 is: ");
                        Num2 = int.Parse(Console.ReadLine());
                        Answer = Num1 + Num2;
                        Console.WriteLine("The answer is: " + Answer);
                        break;
                    case "substract":
                        Console.WriteLine("What 2 numbers would you like to use?");
                        Console.Write("Number 1 is: ");
                        Num1 = int.Parse(Console.ReadLine());
                        Console.Write("Number 2 is: ");
                        Num2 = int.Parse(Console.ReadLine());
                        Answer = Num1 - Num2;
                        Console.WriteLine("The answer is: " + Answer);
                        break;
                    case "multiply":
                        Console.WriteLine("What 2 numbers would you like to use?");
                        Console.Write("Number 1 is: ");
                        Num1 = int.Parse(Console.ReadLine());
                        Console.Write("Number 2 is: ");
                        Num2 = int.Parse(Console.ReadLine());
                        Answer = Num1 * Num2;
                        Console.WriteLine("The answer is: " + Answer);
                        break;
                    case "divide":
                        Console.WriteLine("What 2 numbers would you like to use?");
                        Console.Write("Number 1 is: ");
                        Num1 = int.Parse(Console.ReadLine());
                        Console.Write("Number 2 is: ");
                        Num2 = int.Parse(Console.ReadLine());
                        Answer = Num1 / Num2;
                        Console.WriteLine("The answer is: " + Answer);
                        break;
                    default:
                        Console.WriteLine("This is not an option! Shutting Down..");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
