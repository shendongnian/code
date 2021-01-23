    public static void Main()
    	{
                double TotalAmount;
                TotalAmount = 300.7 + 75.60;
                Console.WriteLine("Your account currently contains this much money: {0:C} ", TotalAmount);
                Console.WriteLine("Would you like to withdraw money? Please type yes or no.");
                string UserInput2 = Console.ReadLine();
                if (UserInput2.ToLower() == "yes") 
                {
                    Console.WriteLine("How much would you like to withdraw?");
                    string UserInput = Console.ReadLine();
                    double UserInput3 = double.Parse(UserInput);
                    TotalAmount = TotalAmount - UserInput3;
                    Console.WriteLine("Thank you. Your new balance is {0:C} ", TotalAmount);
                    Console.WriteLine("Anything else?");
                    string UserInput4 = Console.ReadLine();
    
                    if (UserInput4.ToLower() == "yes")
                    {
                        Console.WriteLine("What do you want to do?");
                        Console.WriteLine("1). Withdraw");
                        Console.WriteLine("2). Deposit");
                        Console.WriteLine("Use number key for selection");
                        string UserInput5 = Console.ReadLine();
                        if (UserInput5.ToLower() == "1")
                        {
                            Console.WriteLine("How much would you like to withdraw?");
                        }
                        else if (UserInput5.ToLower() == "2")
                        {
                            Console.WriteLine("How much would you like to deposit?");
                            string UserInput6 = Console.ReadLine(); //FIRST ERROR
                        }
                    }
                else if (UserInput4.ToLower() == "no") 
                    {
                        Console.WriteLine("Have a nice day, and thanks for talking to me. Being an ATM is lonely :'(");
                        System.Environment.Exit(1);
                    }
                } //SECOND ERROR
                else if(UserInput2.ToLower() == "no") 
                {
                    Console.WriteLine("Have a nice day, and thanks for talking to me. Being an ATM is lonely :'(");
                    System.Environment.Exit(1);
                }
            }
