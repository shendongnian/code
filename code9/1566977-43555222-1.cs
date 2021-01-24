    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp6
    {
        class Program
        {
            public static void Main()
            {
                ConsoleKeyInfo ckilast = default(ConsoleKeyInfo);
                ConsoleKeyInfo ckicurrent = default(ConsoleKeyInfo);
    
                Console.WriteLine("\nPress a key to display; press the 'x' key to quit.");
    
                // Adjust this "window" period, till it feels right
    
                //TimeSpan tsignorerepeatedkeypresstimeperiod = new TimeSpan(0, 0, 0, 0, 0); // 0 for no extra delay
    
                TimeSpan tsignorerepeatedkeypresstimeperiod = new TimeSpan(0, 0, 0, 0, 250);
    
                do
                {
                    while (Console.KeyAvailable == false)
                        Thread.Sleep(250); // Loop until input is entered.
    
                    ckilast = default(ConsoleKeyInfo);
    
                    DateTime eatingendtime = DateTime.UtcNow.Add(tsignorerepeatedkeypresstimeperiod); // will ignore any "repeated" keypresses of the same key in the repeat window
    
                    do
                    {
                        while (Console.KeyAvailable == true)
                        {
                            ckicurrent = Console.ReadKey(true);
    
                            if (ckicurrent.Key == ConsoleKey.X)
                                break;
    
                            if (ckicurrent != ckilast) // different key has been pressed to last time, so let it get handled
                            {
                                eatingendtime = DateTime.UtcNow.Add(tsignorerepeatedkeypresstimeperiod); // reset window period
    
                                Console.WriteLine("You pressed the '{0}' key.", ckicurrent.Key);
    
                                ckilast = ckicurrent;
    
                                continue;
                            }
                        }
    
                        if (Console.KeyAvailable == false)
                        {
                            Thread.Sleep(50);
                        }
    
                    } while (DateTime.UtcNow < eatingendtime);
    
                } while (ckicurrent.Key != ConsoleKey.X);
            }
        }
    }
