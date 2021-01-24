    [TestMethod]
    public void AddItem_ShouldSucceed()
    {
        var myItems = new Mock<MockableDbSetWithExtensions<MyItem>>();
    
        var context = new Mock<MyContext>();
        context.Setup(e => e.MyItems).Returns(myItems.Object);
    
        MyItemService service = new MyItemService(context.Object);
    
        ...
    }
