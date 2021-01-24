    public class ListEntry
    {
        public int ID { get; set; }
        [TypeConverter(typeof(IPAddressConverter))]
        public IPAddress IP { get; set; }
    }
