	public class ApplicationLogEventObject
	{
		public string EventType { get; set; }
		[XmlElement("DateStamp")]
		public string DateStampString { 
			get
			{
				// Replace with culturally invariant desired formatting.
				return DateStamp.ToString(CultureInfo.InvariantCulture);
			}
			set
			{
				DateStamp = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
			}
		}
		[XmlIgnore]
		public DateTime DateStamp { get; set; }
		public string ShortDescription { get; set; }
		public string LongDescription { get; set; }
	}
