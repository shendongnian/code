    public interface IInteractionResult
    {
        void Handle();
    }
    public interface IBall
    {
    	BallTypeEnum BallType { get; }
    
    	IInteractionResult HandleInteraction(IBall ball);
    }
