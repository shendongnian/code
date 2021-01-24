    private FooController _fooController;
    private Mock<ILogger<FooController>> _logger;
    
    [TestInitialize]
    public void Setup()
    {
    	_logger = new Mock<ILogger<FooController>>();
    	_fooController = new FooController(_logger.Object);
    }
