    int correctAnswers = 0;
    foreach(var question in questions.OrderBy(q => random.Next()))
    {
        Console.WriteLine(question.Text);
        do
        {
            var answer = Console.ReadLine();
            
            if (question.IsCorrect(answer))
            {
                Console.WriteLine($"That is correct! {correctAnswers++}/100");
                Thread.Sleep(800);
                Console.Clear();
                Console.WriteLine("You are incorrect.");
             }
        }
        while (string.IsNullOrWhiteSpace(answer));
    }
