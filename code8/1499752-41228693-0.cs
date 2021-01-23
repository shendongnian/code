    [TestMethod]
    public void MyModel_Invalid_When_Prop01_Is_Null()
    {
        var myModel = getMyModelInstance();
        myModel.Prop01 = Null;
        Assert.AreEqual(myModel.IsValid(), false);
    }
