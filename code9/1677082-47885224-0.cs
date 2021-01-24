    private static void Main(string[] args)
            {
                Console.WriteLine(" Enter the number of the film you wish to see :");
                int selection = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your age:");
                int age = int.Parse(Console.ReadLine());
    
                if (selection == 3)
                {
                    if (age < 12)
                    {
                        Console.WriteLine("Are you accompanied by an adult? Answer yes or no");
                        string isAccompanied = Console.ReadLine();
    
                        if (isAccompanied.ToUpper().Equals("NO"))
                        {
                            Console.WriteLine("You are not allowed.");
                            return;
                        }
    
                        Console.WriteLine("You may pass.");
                        return;
                    }
    
                    Console.WriteLine("You may enter");
                    return;
                }
            }
