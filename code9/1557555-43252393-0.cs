    // Example of an action that could throw an exception
    public Try<int> Foo() => () => 10;
    // Synchronous Try
    var result = Foo().IfFail(0);
    // Synchronous Try
    var result = Foo().Match(
        Succ: x => x,
        Fail: e => 0
    );
    // Asynchronous Try
    var result = await Foo().IfFailAsync(0);
    // Asynchronous Try
    var result = await Foo().MatchAsync(
        Succ: x => x,
        Fail: e => 0
    );
    // Manually convert a Try to a TryAsync.  All operations are
    // then async by default
    TryAsync<int> bar = Foo().ToAsync();        
    // Asynchronous Try
    var result = await bar.IfFail(0);
    // Asynchronous Try
    var result = await bar.Match(
        Succ: x => x,
        Fail: e => 0
    );
