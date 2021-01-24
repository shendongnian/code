    public IEnumerable<IResult> MyMethod()
    {
        // Delegate validation to somewhere else. You might wrap an IEnumerable<IResult> here:
        yield return ValidateStuff(someArg);
        // Information messages, etc
        yield return new Message("Hello world!");
        // You might end up with an Exception you didn't expect...
        var tmp = new List<int>();
        tmp[2] = 2; // oopz...
        // ...
        yield return new Result<int>(12); // return 12;
    }
