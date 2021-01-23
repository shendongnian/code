    var values = new Dictionary<MyEnum, int>()
    {
        { MyEnum.First, 25 },
        { MyEnum.Second, 42 }
    };
    var valueForSecond = values[MyEnum.Second]; // returns 42
