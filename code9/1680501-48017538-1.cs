    [TestMethod]
    public void SomeTest()
    {
    	var settings = new ControllerSettings
    	{
    		Setting1 = "Some Value",
    		Setting2 = 123,
    	};
    
    	var options = new Mock<IOptions<ControllerSettings>>();
    	options.Setup(x => x.Value).Returns(settings);
    
    	var controller = new Controller(options.Object);
    
    	//	...
    }
