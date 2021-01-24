    public void TestMethod()
    {
        try
        {
            string details = ThingIAmTesting();
            // shouldn't get here
            Assert.Fail();
        }
        catch (Exception ex)
        {
            Assert.IsTrue(ex.Message.Contains("401");
        }
    }
