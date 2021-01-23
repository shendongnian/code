    [TestMethod( )]
    public void createStage ( )
    {
    	//arrange
    	EnthiranStageViewModel enthiranStage = new EnthiranStageViewModel
    	{
    		StageType=0,
    		TriggerBeginType = Akton.Areas.Challenge.Models.TriggerType.Manual,
    		TriggerEndType= Akton.Areas.Challenge.Models.TriggerType.Manual,
    		TimeLimit = new TimeSpan(9, 6, 13),
    		TriggerBeginTime= new DateTime(2016, 09, 3, 9, 6, 13),
    		TriggerEndTime= new DateTime(2016, 09, 3, 9, 6, 13),
    		StartValueType= Akton.Areas.Challenge.Models.StartValueType.Global,
    		StageDate= new DateTime(2016, 09, 3, 9, 6, 13),
    		Proforma=25,
    		GameId=19,
    		CreatedTime=new DateTime(2016, 09, 3, 9, 6, 13),
    		UpdatedTime= new DateTime(2016, 09, 3, 9, 6, 13),
    		StageName="Test"    
    	};
    	
    	Mock<IPrincipal> mockPrincipal = new Mock<IPrincipal>();
    	//TODO: setup mockPrincipal
    	Mock<IUserContext> mockUserContext = new Mock<IUserContext>();
    	mockUserContext.Setup(p => p.User).Returns(mockPrincipal.Object);
    
    	EnthiranController controller = new EnthiranController(mockUserContext.Object);
    	
    	//act
        var actual = controller.CreateStage(enthiranStage) as RedirectToRouteResult; 
        
        //assert
        Assert.IsNotNull(actual);
    }
  
