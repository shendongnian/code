    public static class SomeClass
    {
        static Func<string> _createId = () => Guid.NewGuid().ToString();
        public static void Configure(Func<string> createId)
        {
            if(createId == null) throw new ArgumentNullException(nameof(createId));
            _createId = createId;
        }
        public static void SomeMethod()
        {
            var id = _createId();
            // do something
        }
    }
