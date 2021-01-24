    public sealed class Delayed {
        private readonly Func<object> _func;
        private bool _hasResolved;
        private object _resolved;
        public Delayed(Func<object> func) {
            _func = func;
        }
        public override string ToString() {
            if (!_hasResolved) {
                _resolved = _func();
                _hasResolved = true;
            }
            if (_resolved == null)
                return "";
            return _resolved.ToString();
        }
    }
