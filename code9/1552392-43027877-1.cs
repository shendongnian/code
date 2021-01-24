    public class Channel
    {
        public string Name { get; set; }
        public DateTime? TxTime { get; set; }
        public Channel()
        {
            Name = string.Empty;
            TxtTime = null;
        }
        public ChannelData ToSerialization()
        {
            var data = new ChannelData();
            data.Name = Name;
            data.txTimeForSerialization = TxTime.HasValue ? TxTime.Value.ToString("o") : null;
        }
    }
