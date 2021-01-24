    private class MySerializationSurrogate<T> : ISerializationSurrogate
	{
        private IEnumerable<DataMemberAttribute> GetXmlAttribs(PropertyInfo p) => p.GetCustomAttributes(false).OfType<DataMemberAttribute>();
		public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
		{
			var myobj = (T)obj;
			foreach (var property in myobj.GetType().GetProperties().Where(p => GetXmlAttribs(p).Any()).OrderBy(p => GetXmlAttribs(p).First().Order))
			{
				info.AddValue(property.Name, property.GetValue(myobj));
			}
		}
		public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			var myobj = (T)obj;
			foreach (var property in myobj.GetType().GetProperties().Where(p => GetXmlAttribs(p).Any()).OrderBy(p => GetXmlAttribs(p).First().Order))
			{
				property.SetValue(myobj, info.GetValue(property.Name, property.PropertyType));
			}
			return null;
		}
	}
