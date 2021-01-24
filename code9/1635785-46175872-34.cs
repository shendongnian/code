    public class NamedBindingIndex<TValue> : IIndex<string, TValue>
    {
        private readonly IKernel _kernel;
        public NamedBindingIndex(IKernel kernel)
        {
            _kernel = kernel;
        }
        public bool TryGetValue(string key, out TValue value)
        {
            value = _kernel.Get<TValue>(key); // eventually catch an Exception here
            return value != null;
        }
        public TValue this[string key]
        {
            get
            {
                TValue value;
                TryGetValue(key, out value);
                return value;
            }
            set { throw new NotSupportedException(); }
        }
    }
