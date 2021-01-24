    var repetitions = 200;
    var predictor = new TimePredictor();
    predictor.Start();
    for (int i = 0; i < repetitions; i++)
    {
        Thread.Sleep((new Random()).Next(0, 250));
        if (i % 5 == 0)
        {
            predictor.Update(i);
            Console.WriteLine($"Iteration #{i}:");
            Console.WriteLine($"\tExpected total time: {predictor.GetExpectedTotalTime(repetitions) / 1000.0:N1}");
            Console.WriteLine($"\tExpected time left: {predictor.GetExpectedTimeLeft(repetitions) / 1000.0:N1}");
            Console.WriteLine();
        }
    }
    predictor.Stop();
    Console.WriteLine($"Total time: {predictor.ElapsedTime / 1000.0:N1}");
