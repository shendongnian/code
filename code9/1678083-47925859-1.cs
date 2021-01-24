    public static void Main()
    {
        bool flag = true;
        while(flag){
            //your game here
            Console.WriteLine("Play again? ('y' or 'n')");
            string playAgain = null;
            playAgain = Console.ReadLine();
            if(playAgain == "n")
                flag == false;
        }
    }
