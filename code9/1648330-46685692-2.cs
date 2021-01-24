    Func<double[], double>[] vandermondeSystem = new Func<double[], double>[100];
    // Constructing a 100 x 50 Vandermonde System
    for (int i = 0; i < 100; i++)
    {
        var i1 = i;
        bigVandermondeSystem[i] = x => Enumerable
            .Range(0, 50)
            .Sum(number => x[number] * Math.Pow(i1 + 1, number));
    }
