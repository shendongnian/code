    static (int count, double sum) Tally(IEnumerable<double> values)
    {
        int count = 0;
        double sum = 0.0;
        foreach (var value in values)
        {
            count++;
            sum += value;
        }
        return (count, sum);
    }
     
    ...
     
    var values = ...
    var t = Tally(values);
    Console.WriteLine($"There are {t.count} values and their sum is {t.sum}");
