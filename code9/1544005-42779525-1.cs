    public class TestHandler : IHandleMessages<SagaStarter>
    {
    	private Context _testContext;
    	
    	public TestHandler(Context testContext)
    	{
    		_testContext = testContext;
    	}
    	
    	public Task Handle(SagaStarter message, IMessageHandlerContext context)
    	{
    		_testContext.IsRequested= true;
    		return Task.CompletedTask;
    	}
    }
