    var chain = new IValidator[]
    {
        new Validator1(),
        new Validator2(),
        new Validator3()
    };
    chain
        .Select(v => v.Validate())
        .Concat()
        .TakeWhile(vr => vr.Status == ValidatorStatus.Successful)
        .Subscribe(
            vr => Console.WriteLine(vr.Status),
            () => Console.WriteLine("Done"));
