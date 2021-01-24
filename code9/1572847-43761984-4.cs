    static bool CheckUserInput(string userInput) // true : valid | false : invalid
    {
        int msec = 5000;
        try
        {
            if (!(userInput == "F5121" || 
                  userInput == "F3111" || 
                  userInput == "F8331" || 
                  userInput == "F5321"))
            {     
                Console.WriteLine("Enter a valid MPN codes for your products");
                return false;
            }
            else
            {
                switch (userInput)
                {
                    case "F5121":
                        Console.WriteLine("barcode 1 is =", userInput);
                        Thread.Sleep(msec);
                        return true;                      
                    case "F3111":
                        Console.WriteLine("barcode 2 is =", userInput);
                        Thread.Sleep(msec);
                        return true;
                    case "F8331":
                        Console.WriteLine("barcode 3 is =", userInput);
                        Thread.Sleep(msec);
                        return true;
                    case "F5321":
                        Console.WriteLine("barcode 4 is =", userInput);
                        return true;
                    default:
                        return false;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    } 
