    [TestMethod]
    public void Action_ThrowsException()
    {
        // test logic here
        ArgumentException aex = Throws<ArgumentException>(()=>{
            // Test logic here
        });
    
        Assert.AreEqual("Expected error message", aex.Message);
    }
