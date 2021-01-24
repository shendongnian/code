    private MyController _ctrl;
    
    [TestInitialize]
    public void Initialize()
    {
    	var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
    	{
    		 new Claim(ClaimTypes.Name, "UserName"),
    		 new Claim(ClaimTypes.Role, "Admin")
    	}));
    
    	_ctrl = new MyController();
    	_ctrl.ControllerContext = new ControllerContext()
    	{
    		HttpContext = new DefaultHttpContext() { User = user }
    	};
    }
    
    [TestMethod]
    public void GetSomeDataTest()
    {
        Assert.AreEqual(_ctrl.GetSomeData(), "Test");
    }
