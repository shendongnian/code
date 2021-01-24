    static void Main(string[] args)
    {
        //create size, and random object
        const int SIZE = 6;
        const int maxNumberInLottery = 1;
        Random rnd = new Random();
        //create int[] for the lot numbers
        int[] lotteryNumbers = new int[SIZE];
        string[] usersNumbers = new string[SIZE];
        //Create a bool[] for each case
        bool[] matches = new bool[SIZE];
        
        //Create lottery numbers
        for (int i = 0; i < SIZE; i++)
        {
            lotteryNumbers[i] = rnd.Next(1, maxNumberInLottery + 1);
        }
        //Read user input
        for(int j = 0; j < SIZE; j++)
        {
            Console.Write("Enter user pick #{0}:", j+1);
            string userInput = Console.ReadLine();
            usersNumbers[j] = userInput;
        }
        //check if matching
        for(int k = 0; k < SIZE; k++)
        {
            Console.Write("You entered: {0}. Lottery generated: {1}", usersNumbers[k], lotteryNumbers[k]);
            Console.WriteLine();
            try
            {
                if (int.Parse(usersNumbers[k]) == lotteryNumbers[k])
                {
                    Console.WriteLine("       !MATCH!");
                    matches[k] = true;
                }
            }
            catch
            {
            }    
        }
        if(matches[0] && matches[1] && matches[2] && matches[3] && matches[4] && matches[5])
        {
            Console.WriteLine("WE HAVE A WINNER!");
        }
        Console.ReadKey();
    }
