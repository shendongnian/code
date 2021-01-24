    public static void SayingHelloUsesName() {
        var sut = new Greeter("Arthur");
        var expected = "Hello Arthur";
        var actual = sut.SayHello();
        Assert.AreEqual(expected, actual);
    }
