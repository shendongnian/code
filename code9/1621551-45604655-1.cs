    static void Main(string[] args)
            {
                /* Initialize everyting to 0 first. */
                SportGoods info = new SportGoods(0,0,0,0);
    
                /* Use this to check whether user input is valid. I put pass = false first 
                 * in order for the while loop logic below to go through at least once. */
                bool pass = false;
    
                Console.WriteLine(@"Hello, and welcome to Dan's Sporting 
                Goods. This program will allow you to calculate the tax and 
                shipping charges for any order that you would like to make. 
                Before using the program, please determine what it is you would 
                like to buy from our website, and how much your order will cost 
                in total, before shipping and tax (The subtotal).");
    
                Console.WriteLine("");
                
                Console.WriteLine(@"How much is the total cost of your order?");
    
                /* Make sure user enter numeric. As long as the input does not pass 
                 * the checking point (pass==false / !pass), show error and continue
                 * to loop. */
                while (!pass)
                {
                    /* Use try catch to catch error. */
                    try
                    {
                        /* Convert will throw error if the input is non-numeric. */
                        info.SubTotal = Convert.ToDecimal(Console.ReadLine());
                        /* If no error is thrown, checking is okay, so set pass = true. */
                        pass = true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input. Please enter numeric value!" + "\n\n");
                        Console.WriteLine(@"How much is the total cost of your order?");
                    }
                }
    
                if (pass)
                {
                    /* For simplicity's sake, I don't perform checking for states. */
                    Console.WriteLine(@"Please enter your state's initials 
                    (For California, use 'CA', for Arizona, use AZ, etc.):");
                    info.State = Console.ReadLine();
                    /* This is the new method I added in. Refer to SportGoods class. */
                    info.PerformCalculation();
                    Console.Write("Your Order cost is: " + info.SubTotal + "\n\n");
                    Console.Write("Your Sales Tax is: " + info.SalesTax + "\n\n");
                    Console.Write("Your Shipping Cost is: " + info.ShippingAmount + "\n\n");
                    Console.Write("Your Grand Total is: " + info.GrandTotal + "\n\n");
                    Console.Write("Press ENTER to end.");
                    Console.Read();
                }
            }
