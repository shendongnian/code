    bool Ask(string question, string answer, int attempts)
    {
        Console.WriteLine(question);
        for (int i = 0; i < attempts; i++)
        {
            string input = Console.ReadLine().ToLower();
            if (input == answer)
            {
                Console.WriteLine("Correct!");
                return true;
            }
             Console.WriteLine("Incorrect.");
        }
         return false;
    }
    static void Main()
    {
        int score = 0;
        if (Ask("Where is Walt Disney World Park located in Florida? A.Orlando,B.Tallahassee, C. Miami, or D. Tampa", "B", 3))
        {
            score += 50;
        }
        else
        {
            score -= 50;
        }
        Console.WriteLine("Score :" + score);
    }
