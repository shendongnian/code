    public sealed class SomeClass : ISomeClass
    {
        private readonly TimeTrackerContext _context;
        public void Dispose()
        {
            _context.Dispose();
        }
    }
