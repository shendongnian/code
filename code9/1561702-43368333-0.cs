    public static void Main(string[] args)
    {
        int intNr;
        double doubleNr = 0;
        while(true)
        {
            try
            {
                Console.WriteLine("Enter your number: ");
                string strNr = Console.ReadLine();
                doubleNr = Int32.Parse(strNr);
                if(doubleNr < 20)
                {
                    throw new Exception("Try a higher number.");
                }
                else if(doubleNr > 30)
                {
                    throw new Exception("Try a lower number.");
                }
                else
                {
                    Console.WriteLine("That is a good number.");
                    break;
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine("Enter a valid number.");
                continue;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }
    }
