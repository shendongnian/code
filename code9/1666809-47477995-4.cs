    public class Disposable : IDisposable {
        private readonly Action _action;
        private Disposable(Action action) {
            _action = action;
        }
        public static IDisposable FromAction(Action action) {
            return new Disposable(action);
        }
        public void Dispose() {
            _action();
        }
    }
