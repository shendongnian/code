        [Serializable]
    public class WebServiceInputGetDataParams : ISerializable
    {
        public Dictionary<string, object> Entries
        {
            get { return entries; }
        }
        private Dictionary<string, object> entries;
        public WebServiceInputGetDataParams()
        {
            entries = new Dictionary<string, object>();
        }
        protected WebServiceInputGetDataParams(SerializationInfo info, StreamingContext context)
        {
            entries = new Dictionary<string, object>();
            foreach (var entry in info)
            {
                entries.Add(entry.Name, entry.Value);
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (var entry in entries)
            {
                info.AddValue(entry.Key, entry.Value);
            }
        }
    }
