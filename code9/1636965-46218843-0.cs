    [TestMethod]
    public void UT_UU()
    {
        // Arrange
        var subject = new Foo();
        try
        {
            // Act
            subject.Bar();
        }
        catch(ArgumentException ae)
        {
            Assert.AreEqual("my message", ae.Message);
            return;
        }
        catch(Exception e)
        {
            Assert.Fail("Thrown exception was of wrong type"); // would provide more detail here
        }
        Assert.Fail("exception should have been thrown");
    }
