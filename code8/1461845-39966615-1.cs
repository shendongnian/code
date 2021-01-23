    public sealed class SomeClass : ISomeClass
    {
        private readonly TimeTrackerContext _context;
        private bool _dispose;
        public SomeClass(TimeTrackerContext context, bool dispose = true)
        {
            _context = context;
            _dispose = dispose;
        }
        public void Dispose()
        {
            if (_dispose)
            {
                _context.Dispose();
            }
        }
    }
