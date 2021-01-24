	int _;
    int.TryParse("123", out var _); // discard
    Console.WriteLine(_); // error: variable is not assigned
    int.TryParse("123", out _); // passes existing variable byref
    Console.WriteLine(_); // ok: prints "123"
