    [Test]
    [TestCase("Jerkface")]
    [TestCase("jerKfAcE")]
    //[TestCase("...")]
    public void process_CensorCode_GivenJerkface_ReturnsStringWithoutJerkface(string checkedWord)
    {
    	//ACT
    	string result = proc.process("Jerkface you Jerkfacing Jerkfacer &*E@*Jerkface391!!", PROCESS_CODE.CENSOR);
    	//ASSERT
    	Assert.IsFalse(result.Contains(checkedWord));
    }
