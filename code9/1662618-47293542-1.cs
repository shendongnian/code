    private static void Main()
    {
        var input = "What is Facebook?.| A. Website B. Internet C. Social Network D. Game";
        var qa = QuestionAndAnswers.Parse(input);
        Console.WriteLine(qa);
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
