    string questionOne;
    do
    {
        Console.WriteLine("(Press a corresponding number on the keyboard and press enter)");
        Console.WriteLine("1.) How your day is going");
        Console.WriteLine("2.) Relationships");
        questionOne = Console.ReadLine();
        if (questionOne == "1")
        {
            // questions about how your day is going
        }
        else if (questionOne == "2")
        {
            // relationships questions
        }
        else
        {
            Console.WriteLine("I didn't understand your answer. Try again.");
        }
    } while (questionOne != "1" && questionOne != "2");
