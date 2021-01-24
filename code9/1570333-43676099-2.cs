	public static class DeviceExtensions
	{
		public static string SerializeDevice<TDevice>(this TDevice o) where TDevice : Device
		{
			// Ensure that [XmlInclude(typeof(TDevice))] is present on Device.
			// (Included for clarity -- actually XmlSerializer will make a similar check.)
			if (!typeof(Device).GetCustomAttributes<XmlIncludeAttribute>().Any(a => a.Type == o.GetType()))
			{
				throw new InvalidOperationException("Unknown device type " + o.GetType());
			}
			var serializer = new XmlSerializer(typeof(Device)); // Serialize as the base class
			using (var stringWriter = new StringWriterWithEncoding(Encoding.UTF8))
			{
				serializer.Serialize(stringWriter, o);
				return stringWriter.ToString();
			}
		}
		
		public static Device DeserializeDevice(this string xml)
		{
			var serial = new XmlSerializer(typeof(Device));
            using (var reader = new StringReader(xml))
            {
				return (Device)serial.Deserialize(reader);
			}
		}
	}
