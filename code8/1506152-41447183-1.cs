    public class Example
    {
        private SynchronizationContext _context;
        public Example()
        {
            var existingContext = SynchronizationContext.Current;
            _context = existingContext != null ? existingContext.CreateCopy() : new SynchronizationContext();
        }
        public virtual event LogEventHandler EntryReceived;
        protected virtual void ReceiveEntry(ILogEntry entry)
        {
            _context.Send(ContextCallback, entry);
        }
        private void ContextCallback(object entry)
        {
            var temp = EntryReceived;
            if (temp != null)
            {
                temp(this, new LogEventArgs() {Entry = (ILogEntry)entry});
            }
        }
    }
