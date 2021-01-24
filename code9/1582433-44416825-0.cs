    [TestMethod]
    public void ExampleTest()
    {
        //fakes the next BankApi instace 
        var handler = Isolate.Fake.NextInstance<BankApi>();
        
    	//change the pay method behavior
        Isolate.WhenCalled(() => handler.pay()).WillReturn(1);
    
        new ClassUnderTest().Pay();
    }
