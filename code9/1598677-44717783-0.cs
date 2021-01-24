    var allowedQuestions = new Dictionary<string, List<string>>
    {
        { "question 1", state },
        { "question 1", joke },
        { "question 1", yourName }
    };
    
    var input = Console.ReadLine();
    
    if(allowedQuestions.ContainsKey(input))
    {
        var answers = allowedQuestions[input];
        var randIndex = rand.Next(0, answers.Count - 1);
        Console.WriteLine(answers[randIndex]);
        Discussion();
    }
    else
    {
        Console.WriteLine("no answer");
    }
