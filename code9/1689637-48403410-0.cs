    [JsonObject]
    public class Collection : IEnumerable<Entry>
    {
        public IEnumerable<Entry> Entries { get; };
        public GetEnumerator() {
           return Entries.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
