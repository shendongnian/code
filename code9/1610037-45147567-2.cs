    public class UserEntryFlags
    {
        private readonly Dictionary<EntryEventType, EntryEvent> UserEntryFlagDict = new Dictionary<EntryEventType, EntryEvent>();
        public UserEntryFlags()
        {
            UserEntryFlagDict.Add(EntryEventType.NewEntry, new EntryEvent(EntryEventType.NewEntry));
            UserEntryFlagDict.Add(EntryEventType.DeletedEntry, null);
            // ...
        }
        public EntryEvent this[EntryEventType type]
        {
            get
            {
                return UserEntryFlagDict[type];
            }
            set
            {
                UserEntryFlagDict[type] = value;
            }
        }
    }
