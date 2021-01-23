    public class Example
    {
        private SynchronizationContext _context;
        public Example()
        {
            var existingContext = SynchronizationContext.Current;
            _context = existingContext?.CreateCopy() ?? new SynchronizationContext();
        }
        public virtual event LogEventHandler EntryReceived;
        protected virtual void ReceiveEntry(ILogEntry entry)
        {
            _context.Send(ContextCallback, entry);
        }
        private void ContextCallback(object entry)
        {
            EntryReceived?.Invoke(this, new LogEventArgs() { Entry = (ILogEntry)entry });
        }
    }
