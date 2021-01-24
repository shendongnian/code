    //...
    private Mock<IConfigHelper> configHelperMOCK;
    
    [SetUp]
    public void Setup()
    {
        configHelperMOCK = new Mock<IConfigHelper>();
        UtilService.CreatorFunc = () => configHelperMOCK.Object;
    }
    //...
