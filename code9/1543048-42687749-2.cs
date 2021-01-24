    public class SoccerBall : IBall
    {
    	public BallTypeEnum BallType
    	{
    		get { return BallTypeEnum.Soccer; }
    	}
    
    	public IInteractionResult HandleInteraction(IBall ball)
    	{
    		switch (ball.BallType)
    		{
    			case BallTypeEnum.Soccer:
    				return new BounceInteractionResult();
    			case BallTypeEnum.Bowl:
    				return new DestroyInteractionResult();
    			case BallTypeEnum.PingPong:
    				return new BounceInteractionResult();
    			// and so on
    		}
    
    		throw new NotImplementedException("Undefined ball type");
    	}
    }
