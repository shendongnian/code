    class Account
    {
        public decimal CurrentBalance { get; set; }
        public int timesWithdrawn { get; set; } = 9;
        public decimal WithDraw()
        {
            decimal amountWithdrawnToday = 0;
            decimal money = 0;
            bool success = false;
            if (timesWithdrawn < 10)
            {
                do
                {
                    //Console.WriteLine("{0} available to withdraw.", FundsAvailable);
                    Console.WriteLine("How much would you like to withdraw?");
                    try
                    {
                        money = decimal.Parse(Console.ReadLine());
                        if (money % 5 == 0 && money <= CurrentBalance && money <= 1000)
                        {
                            success = true;
                        }
                        if (money == 0)
                        {
                            bool exit = true;
                            Console.WriteLine("Do you want to exit? Type \"yes\", or \"no\".");
                            while (exit == true)
                            {
                                string response = Console.ReadLine();
                                if (response.ToLower() == "yes")
                                {
                                    break;
                                }
                                else
                                {
                                    exit = false;
                                }
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a number to withdraw.");
                    }
                } while (success == false);
                //do while this is true
                Console.WriteLine(CurrentBalance);
                Console.WriteLine("Withdrawing {0} pounds.", money);
                Console.WriteLine("You have {0} remaining in your account.", CurrentBalance - money);
                amountWithdrawnToday += money;
                timesWithdrawn += 1;
                Console.WriteLine("{0} pounds withdrawn today", amountWithdrawnToday);
                return CurrentBalance -= money;
            }
            else
            {
                Console.WriteLine("You have exceeded daily withdrawls. You have withdrawn {0}", amountWithdrawnToday);
                return amountWithdrawnToday;
            }
        }
    }
