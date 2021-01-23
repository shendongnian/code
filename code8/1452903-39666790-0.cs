    public class SomeClass
    {
        readonly Func<string> _createId;
        public SomeClass() : this(null) {}
        public SomeClass(Func<string> createId)
        {
            _createId = createId ?? () => Guid.NewGuid().ToString();
        }
        public void SomeMethod()
        {
            var id = _createId();
            // do something
        }
    }
