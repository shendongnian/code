	public static class XmlExtensions
	{
		static Type GetSerializedType(this Type type)
		{
			var serializedType = type.BaseTypesAndSelf().Where(t => Attribute.IsDefined(t, typeof(XmlBaseTypeAttribute))).SingleOrDefault();
			if (serializedType != null)
			{
				// Ensure that [XmlInclude(typeof(TDerived))] is present on the base type
				// (Included for clarity -- actually XmlSerializer will make a similar check.)
				if (!serializedType.GetCustomAttributes<XmlIncludeAttribute>().Any(a => a.Type == type))
				{
					throw new InvalidOperationException(string.Format("Unknown subtype {0} of type {1}", type, serializedType));
				}
			}
			return serializedType ?? type;
		}
		
		public static string Serialize(this object o)
		{
			var serializer = new XmlSerializer(o.GetType().GetSerializedType());
			using (var stringWriter = new StringWriterWithEncoding(Encoding.UTF8))
			{
				serializer.Serialize(stringWriter, o);
				return stringWriter.ToString();
			}
		}
			
		public static T Deserialize<T>(this string xml)
		{
			var serial = new XmlSerializer(typeof(T).GetSerializedType());
            using (var reader = new StringReader(xml))
            {
				return (T)serial.Deserialize(reader);
			}
		}
	}
