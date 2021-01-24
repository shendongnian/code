    public static void Main()
    {
        Random numGen = new Random();
        int succeses = 0;
        const int TRIES = 10000;
        for(int i = 0; i < TRIES;i++)
        {
            bool allSixes = true;
            const int DICE_PER_TRY =2;
            for(int j = 0; j < DICE_PER_TRY; j++)
            {
                if(numGen.Next(1, 7) == 6)
                {
                    // still good
                }
                else
                {
                    allSixes = false;
                    break; // might a well give up and
                           // **start the next test**
                           // (reset the test)
                }
            }
            if (allSixes) succeses++;
        }
        var triesPerSuccess = TRIES / succeses;
        Console.WriteLine(triesPerSuccess);
        Console.ReadKey();
    }
