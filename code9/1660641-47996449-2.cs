    public class MyReqRespProcessor : IConsumer<IMyRequest>
    {
    	private readonly IActorRef _myActor;
    	
    	public async Task Consume(ConsumeContext<IMyRequest> context)
    	{
    		TimeSpan? clientTimeout = context.GetClientTimeout();
    		
    		var response = await 
    			_myActor
    			.Ask<IMyResponse>(context.Message, clientTimeout ?? PredefinedTimeout)
    			.ConfigureAwait(false);
    			
    		await
    			context
                .RespondAsync<IMyResponse>(response)
                .ConfigureAwait(false);	
    	}
    }
