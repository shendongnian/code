    public class ActivationToken
    {
        protected ITimeProvider TimeProvider;
    
        public ActivationToken()
        {
            TimeProvider = ServiceResolver.Instance.GetService<ITimeProvider>();
        }
    
        public virtual DateTime? ConsumedTime { get; protected set; }
    
        public virtual void Consume()
        {
            ConsumedTime = TimeProvider.GetTime();
        }
    }
