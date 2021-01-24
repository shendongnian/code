    [JsonArray]
    public class Collection: ICollection<Entry>
    {
        
        public LinkedList<Entry> Entries { get; } = new LinkedList<Entry>();
        public void Add(Entry item)
        {
            Entries.AddLast(item);
        }
    ...
