    public class Journal
    {
        public class JournalEntry { }
        public class JournalEntry<T> : JournalEntry
        {
            protected JournalEntry()
            {
            }
            static protected JournalEntry<T> NewJournalEntry()
            {
                return new JournalEntry<T>();
            }
        }
        private class Maker<T> : JournalEntry<T>
        {
            new static public JournalEntry<T> NewJournalEntry()
            {
                return JournalEntry<T>.NewJournalEntry();
            }
        }
        public JournalEntry<T> NewJournalEntry<T>()
        {
            return Maker<T>.NewJournalEntry();
        }
    }
