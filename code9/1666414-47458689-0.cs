    public interface ISubscription : IDisposable {
        Message NextMessage(TimeSpan? timeout);
    }
    public class Message {
        
    }
