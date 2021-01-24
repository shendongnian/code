    foreach (Question question in questions)
    {
        bool answeredCorrectly = false;
        for (int i = 0; i < 2; ++i)  // up to 2 chances
        {
            Console.Write(question.Text);
            string answer = Console.ReadLine();
            if (answer == question.Answer)
            {
                Console.WriteLine("You answered correctly!");
                answeredCorrectly = true;
                break;  // Make sure we break out of the for loop so we don't ask a second time
            }
            else
            {
                Console.WriteLine("That's not correct.");
            }
        }
        if (answeredCorrectly)
        {
            // Add 50 points to their score, etc.
        }
    }
