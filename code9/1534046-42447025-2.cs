    public partial class DateSafeDelivery : Delivery
    {
        [XmlElement("sentDate")]
        public string sentDateString
        {
            get { return sentDate.HasValue ? XmlConvert.ToString(sentDate.Value, XmlDateTimeSerializationMode.Utc) : null; }
            set { sentDate = DateTime.Parse(value); }
        }
