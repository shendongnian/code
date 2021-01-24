    public class ActivationToken
    {
    
        public ActivationToken()
        {
        }
    
        public virtual DateTime? ConsumedTime { get; protected set; }
    
        public virtual void Consume(ITimeProvider timeProvider)
        {
            ConsumedTime = timeProvider.GetTime();
        }
    }
