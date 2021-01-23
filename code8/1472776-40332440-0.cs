    static public int input()
        {
         Prompt:
            Console.WriteLine("Enter The Number Of Student You Want to get Record");
            int x;
            string inputString = Console.ReadLine();
            if (int.TryParse(inputString, out  x))
            {
                Console.WriteLine(inputString + " Is Integer");
                return x;
            }
            else
            {
                goto Prompt;
            }
    
        }
