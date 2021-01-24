    [JsonObject]
    public class Entry
    {
        public Entry(double[] vals)
        {
            if (vals.Length == 2)
            {
                value = (int)vals[0];
                percent = vals[1];
            }
        }
        public int value { get; set; }
        public double percent { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class Item
    {        
        [JsonProperty(propertyName: "entries")]
        public List<double[]> rawEntries { get; set; }
        public List<Entry> entries
        {
            get
            {
                return rawEntries.Select(arr => new Entry(arr)).ToList();
            }
        }
    }
