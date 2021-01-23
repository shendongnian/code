        using System;
        using System.Threading;
    
    static void Main(string[] args)
                {
                    Console.WriteLine("Please type \"start\" and press ENTER");
                    while (true)
                    {
                        var userInput = Console.ReadLine();
        
                        if (userInput.Equals("start"))
                        {
                            break;
                        }
                        Console.WriteLine("Not correct, please try again");
                    }
        
        
                    var minutes = 10;
                    Console.WriteLine("Going to sleep for " + minutes + " Minutes...");
                    Thread.Sleep(1000 * minutes * 60);
                    
                    Console.WriteLine("Done...");
        
                    Console.ReadLine();
                }
