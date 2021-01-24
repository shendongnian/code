    public class Journal
    {
        public JournalEntry<T> NewJournalEntry<T>()
        {
            return JournalEntryFactory<T>._new();
        }
    
        private static class JournalEntryFactory<T>
        {
            public static Func<JournalEntry<T>> _new;
        }
    
        public Journal() { }
    
        public class JournalEntry { }
    
        public class JournalEntry<T> : JournalEntry
        {
            static JournalEntry()
            {
                JournalEntryFactory<T>._new = () => new JournalEntry<T>();
            }
    
            private JournalEntry()
            {
    
            }
        }
    }
