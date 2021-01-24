    public sealed class Delayed {
        private readonly Lazy<object> _lazy;
        public Delayed(Func<object> func) {
            _lazy = new Lazy<object>(func, false);
        }
        public override string ToString() {
            var result = _lazy.Value;
            return result != null ? result.ToString() : "";
        }
    }
