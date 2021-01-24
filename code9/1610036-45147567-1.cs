    public class EntryEvent
    {
        public EntryEvent(EntryEventType type)
        {
            EventType = type;
        }
        public EntryEventType EventType { get; set; }
        public bool? Flag { get; private set; }
        public DateTime? LastChanged { get; private set; }
        public static EntryEvent GetTrue(EntryEventType type)
        {
            var e = new EntryEvent(type);
            e.SetFlag(true);
            return e;
        }
        public static EntryEvent GetFalse(EntryEventType type)
        {
            var e = new EntryEvent(type);
            e.SetFlag(false);
            return e;
        }
        public void SetFlag(bool flag)
        {
            Flag = flag;
            LastChanged = DateTime.Now;
        }
    }
