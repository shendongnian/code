    public static void FillContestArray(string[,] talentCodes)
    {
        int x = 0;
        for (x = 0; x < talentCodes.GetLength(0); x++)
        {
            Console.WriteLine("Enter contestant's name: ", x + 1);
            talentCodes[x,0] = Console.ReadLine();
            Console.WriteLine("Enter contestant's talent: ", x + 1);
            talentCodes[x,1] = Console.ReadLine();
        }
    }
