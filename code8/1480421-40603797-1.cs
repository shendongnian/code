    public class KSPDJOBWinWCFService : IKSPDJOBWinWCFService
    {
        public event EventHandler<CustomEventArgs> EventA;
    
        public bool SomeWcfOperation(int value)
        {
            EventA?.Invoke(this, new CustomEventArgs(value));
            
            return true;
        }
    }
