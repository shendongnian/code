    var passedCount = 0;
    var failedCount = 0;
    for (var i = 0; i < marks.Length; i++)
    {
        if (marks[i] >= 50)
        {
            passedCount++;
        }
        else
        {
            failedCount++;
        }
    }
    Console.WriteLine("Passed count : "+ passedCount);
    Console.WriteLine("Failed count : "+ failedCount);
