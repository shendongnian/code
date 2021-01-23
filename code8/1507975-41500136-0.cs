        byte answer = 0;
        Console.WriteLine("What is 27+4?");
        string s = Console.ReadLine();
       
        if (byte.TryParse(s, out answer) && answer == 31)
        {
            bool answerCorrect = true;
            if (answerCorrect == true)
                Console.WriteLine("Correct!");
        }
