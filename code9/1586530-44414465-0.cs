    public class SyncInfo: RealmObject
    {
        public Contact contact { get; set; }
        public int isSync { get; set; }     
        public long timestamp { get;set; }
    }
