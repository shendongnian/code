    [TestCase("This is the Test string.", "This is", "Test string.", "AND")]
    [TestCase("This is the Test string.", "This is", "FooBar", "OR")]
    public void Return_CheckJUNK_GetComperatorForConditions(string whereClause, string conditionLeft, string conditionRight, string expectedComparator)
    {
        var args = new object[] { whereClause, conditionLeft, conditionRight };
    
        var objPrivate = new PrivateObject(typeof(ManageConfigurations));
        var result = (string)objPrivate.Invoke("GetComperatorForConditions", args);
    
        Assert.AreEqual(expectedComparator, result);
    }
