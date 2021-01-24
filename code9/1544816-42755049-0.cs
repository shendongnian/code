You can modify your class in order to have _new as a Dictionary instead, which will allow for multiple types to be created:
    public class Journal
    {
        private static IDictionary<Type, Func<JournalEntry>> _new = new Dictionary<Type, Func<JournalEntry>>();
    
        public JournalEntry<T> NewJournalEntry<T>()
        {
            return (JournalEntry<T>)_new[typeof(T)]();
        }
    
        public Journal() { }
    
        public class JournalEntry { }
    
        public class JournalEntry<T> : JournalEntry
        {
            static JournalEntry()
            {
                _new.Add(typeof(T), () => new JournalEntry<T>());
            }
    
            private JournalEntry()
            {
    
            }
        }
    
    }
