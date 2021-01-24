    public class EventSubscription : IDisposable {
        private readonly Action _unsubscribe;
        private EventSubscription(Action subscribe, Action unsubscribe) {
            _unsubscribe = unsubscribe;
            subscribe();
        }
        public static IDisposable Create(Action subscribe, Action unsubscribe) {
            return new EventSubscription(subscribe, unsubscribe);
        }
        public void Dispose() {
            _unsubscribe();
        }
    }
