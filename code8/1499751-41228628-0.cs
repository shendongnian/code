    [TestMethod]
    public void MyModel_Invalid_When_Prop01_Is_Null()
    {
        var myModel = getValidModel();
        myModel.Prop01 = null;    
        Assert.AreEqual(myModel.IsValid(), false);
    }
    
    [TestMethod]
    public void MyModel_Invalid_When_Prop02_Is_Null()
    {
        var myModel = getValidModel();
        myModel.Prop02 = null;
    
        Assert.AreEqual(myModel.IsValid(), false);
    }
    
    [TestMethod]
    public void MyModel_Invalid_When_Prop03_Is_Null()
    {
        var myModel = getValidModel();
        myModel.Prop03 = null;
    
        Assert.AreEqual(myModel.IsValid(), false);
    }
    MyModel getValidModel() => 
        new MyModel
        {
            Prop01 = "Some value",
            Prop02 = "Some value",
            Prop03 = "Some value",
        };
