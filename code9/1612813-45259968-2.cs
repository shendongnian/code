    static void Main(string[] args)
    {
        // Create a new test
        var test = new StaffTest
        {
            QuizItems = new List<QuizItem>
            {
                new QuizItem("What it the capital of Washington State?", 
                    new List<string> {"Seattle", "Portland", "Olympia" }, 2),
                new QuizItem("What it the sum of 45 and 19?", 
                    new List<string> {"64"}, 0),
                new QuizItem("Which creature is not a mammal?", 
                    new List<string> {"Dolphin", "Shark", "Whale" }, 1)
            }
        };
        Console.Write("Press any key to start the test...");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n\n(Test started at {DateTime.Now})\n");
        Console.ResetColor();
        test.BeginTest();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"(Test ended at {DateTime.Now})\n");
        Console.ResetColor();
        Console.WriteLine($"Thank you for taking the test.\n");
        Console.WriteLine($"You scored ................ {test.Score} / {test.QuizItems.Count}");
        Console.WriteLine($"Your percent correct is ... {test.ScorePercent.ToString("N0")}%");
        Console.WriteLine($"Your grade is ............. {test.Grade}");
        Console.WriteLine($"The total time was ........ {test.ElapsedSeconds.ToString("N2")} seconds");
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
