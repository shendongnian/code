    public interface IJournalEntry<T>
    {
    }
    
    public class Journal
    {
        public IJournalEntry<T> NewJournalEntry<T>()
        {
            return new JournalEntry<T>();
        }
    
        public Journal() { }
    
        private class JournalEntry<T> : IJournalEntry<T>
        {
            public JournalEntry()
            {
    
            }
        }
    }
