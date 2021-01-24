    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    namespace Practicing
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    int TotalCoffeeCost = 0;
                    string UserDecision = string.Empty;
                    do
                    {
                        int UserChoice = -1;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Please Enter Your Choice: 1-Small,2-Medium,3-Large");
                            UserChoice = int.Parse(Console.ReadLine());
                            switch (UserChoice)
                            {
                                case 1:
                                    TotalCoffeeCost += 50;
                                    break;
                                case 2:
                                    TotalCoffeeCost += 70;
                                    break;
                                case 3:
                                    TotalCoffeeCost += 100;
                                    break;
                                default:
                                    Console.WriteLine("Your choise {0} Is Invalid", UserChoice);
                                    break;
                            }
                        } while (UserChoice != 1 && UserChoice != 2 && UserChoice != 3);
                        do
                        {
                            Console.WriteLine("Do you want to buy another coffee Yes or No");
                            UserDecision = Console.ReadLine().ToUpper();
                            if (UserDecision != "YES" && UserDecision != "NO")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Your Choise {0} is invalid ", UserDecision);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        } while (UserDecision != "YES" && UserDecision != "NO");
                    }
                    while (UserDecision.ToUpper() != "NO");
                    Console.WriteLine("Thank you For shopping with us \n Your bill is generating. Please wait...");
                    Thread.Sleep(3000);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Your bill is {0}", TotalCoffeeCost);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("(Press any key to exit)");
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
            }
    
        }
    }
