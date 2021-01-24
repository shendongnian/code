    // The abstraction in question
    public interface IMyService
    {
        ServiceData GetData();
    }
    // The heavy implementation
    public class HeavyInitializationService : IMyServic {
        public HeavyInitializationService() {
            // Load data here
            Thread.Sleep(3000);
        }
        public ServiceData GetData() => ...
    }
