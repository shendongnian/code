    [Test]
    public void TestThatMyExceptionWillNotBeThrown()
    {
        try
        {
            TheMethodToTest();
    
            // if the method did not throw any exception, the test passes
            Assert.That(true);
        }
        catch(Exception ex)
        {
            // if the thrown exception is MyException, the test fails
            Assert.IsFalse(ex is MyException);
        }
    }
