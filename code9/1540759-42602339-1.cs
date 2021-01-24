    static void Main(string[] args)
    {
        int userInput = 0;
        do
        {
            userInput = DisplayMenu();
            if (userInput == 1)
            {
                QuickClean();
            }
            ....
        } while(userInput != 4)
    }
