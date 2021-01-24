    public class Delayed {
        private readonly Func<object> _func;
        private bool _hasResolved;
        private string _resolved;
        public Delayed(Func<object> func) {
            _func = func;
        }
        public override string ToString() {
            if (!_hasResolved) {
                var result = _func();
                if (result == null)
                    _resolved = "";
                else
                    _resolved = result.ToString();
                _hasResolved = true;
            }
            return _resolved;
        }
    }
