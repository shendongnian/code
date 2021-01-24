    private class MySerializationSurrogate<T> : ISerializationSurrogate
	{
		public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context)
		{
			var myobj = (T)obj;
			Func<System.Reflection.PropertyInfo, IEnumerable<DataMemberAttribute>> getXmlAttrib = (p) => p.GetCustomAttributes(false).OfType<DataMemberAttribute>();
			foreach (var property in myobj.GetType().GetProperties().Where(p => getXmlAttrib(p).Any()).OrderBy(p => getXmlAttrib(p).First().Order))
			{
				info.AddValue(property.Name, property.GetValue(myobj));
			}
		}
		public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			var myobj = (T)obj;
			Func<System.Reflection.PropertyInfo, IEnumerable<DataMemberAttribute>> getXmlAttrib = (p) => p.GetCustomAttributes(false).OfType<DataMemberAttribute>();
			foreach (var property in myobj.GetType().GetProperties().Where(p => getXmlAttrib(p).Any()).OrderBy(p => getXmlAttrib(p).First().Order))
			{
				property.SetValue(myobj, info.GetValue(property.Name, property.PropertyType));
			}
			return null;
		}
	}
