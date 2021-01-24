    int GetIntBetween(int min, int max) //inclusive
    {
        int result;
        string str = Console.ReadLine();
        while (true)
        {
            if (Int32.TryParse(str, out result))
            {
                if (result >= min && result <= max)
                    break;
            }
            
            Console.WriteLine(String.Format("Only integer between {0} and {1} (inclusive) is allowed, please reenter another value.", min, max));
            str = Console.ReadLine();
        }
        return result;
        
    }
