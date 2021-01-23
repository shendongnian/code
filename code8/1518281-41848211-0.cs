    [TestMethod]
    public void TheTest()
    {
        switch ( DataSource["TestToRun"] )
        {
            case "DoThisFirst" : DoThisFirst(); break;
            case "DoThisSecond" : DoThisSecond(); break;
            default: Assert.Fail("Unknown test."); break;
        }
    }
