    [Test]
    public async void Foo() // < -- Error : Async test method must have non-void return type
    {
         var myResult = await classBeingTested.DoSomethingAsync();
         // Post continuation assertions here.
    }
