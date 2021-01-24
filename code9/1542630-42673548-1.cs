    public static MyClass MyClass2 => new MyClass(MyClass1)
    {
        Property1 = 42,
        Property2 = "some other text",
        Property3 = new MyOtherClass(MyEnum.SomethingElse)
    };
