    static void Main()
            {
                Console.Write("Enter the number of times to print \"Yay!\": ");
                while (true)
                {
                    string times = Console.ReadLine();
                    if (times != null)
                    {
                        try
                        {
                            int repeater = int.Parse(times);
                            if(repeater < 0)
                            {
                                Console.WriteLine("You must enter a positive number.");
                                return;
                            }
                            else
                            {
                                while (repeater > 0)
                                {
                                    Console.WriteLine("Yay!");
                                    repeater--;
                                }
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("You must enter a whole number!");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                Console.ReadLine();
            }
