    public interface IExpirable {
        bool IsExpired { get; set; }
        DateTime ExpirationTime { get; }
    }
    public class ExpirationManager {
        private readonly List<IExpirable> _items = new List<IExpirable>();
        public ExpirationManager(IEnumerable<IExpirable> items) {
            _items.AddRange(items);
            Trigger();
        }
        public void Add(IExpirable item) {
            lock (_items)
                _items.Add(item);
            // reset current timer and repeat
            Trigger();
        }
        public void Remove(IExpirable item) {
            lock (_items)
                _items.Remove(item);
            // reset current timer and repeat
            Trigger();
        }
        private Timer _timer;
        private void Trigger() {
            // reset first
            if (_timer != null) {
                _timer.Dispose();
                _timer = null;
            }
            IExpirable next;
            lock (_items) {
                next = _items.Where(c => !c.IsExpired).OrderBy(c => c.ExpirationTime).FirstOrDefault();
            }
            if (next == null)
                return; // no more items to expire
            var dueTime = next.ExpirationTime - DateTime.Now;
            if (dueTime < TimeSpan.Zero) {
                // already expired, process here
                next.IsExpired = true;
                // and repeat
                Trigger();
            }
            else {
                _timer = new Timer(TimerTick, next, dueTime, Timeout.InfiniteTimeSpan);
            }
        }
        private void TimerTick(object state) {
            ((IExpirable)state).IsExpired = true;
            // repeat
            Trigger();
        }
    }
