    public class BlobItem : IBlobItem
    {
        public BlobItem()
        {
            TypeXDataDictionary = new TypeXDictionary<IEnumerable<IDataItem>>();
        }
        [JsonProperty(ItemConverterType = typeof(TypeConverter<IEnumerable<IDataItem>, List<DataItem>>))]
        public TypeXDictionary<IEnumerable<IDataItem>> TypeXDataDictionary { get; set; }
    }
