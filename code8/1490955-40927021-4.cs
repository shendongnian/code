    ...
    Int64 startTime2 = Stopwatch.GetTimestamp();
    for (int i = 0; i < 1000; i++)
    {
        Double sum = numbers.SumX();
        sums2[i] = sum;
    }
    Int64 endTime2 = Stopwatch.GetTimestamp();
    ...
