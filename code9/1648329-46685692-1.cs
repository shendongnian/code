    Func<double[], double>[] vandermondeSystem = new Func<double[], double>[100];
    // Constructing a 100 x 50 Vandermonde System
    for (int i = 0; i < 100; i++)
    {
        vandermondeSystem[i] = x => Enumerable
            .Range(0, 50)
            .Sum(number => Math.Pow(x[i], number));
    }
