    private static void Serialize()
	{
		XsdClass xc = new XsdClass();
		xc.SomeString1 = string.Empty;
		xc.SomeString2 = "value";
		xc.SomeString3 = null;
		XmlAttributeOverrides overrides = new XmlAttributeOverrides();
		XmlAttributes attribs = new XmlAttributes();
		attribs.XmlDefaultValue = string.Empty;
		foreach (var prop in TypeDescriptor.GetProperties(typeof(XsdClass)).Cast<PropertyDescriptor>().Where(x => !x.IsReadOnly && x.PropertyType == typeof(string)))
			overrides.Add(typeof(XsdClass), prop.Name, attribs);
		XmlSerializer serializer = new XmlSerializer(typeof(XsdClass), overrides);
		string result;
		using (StringWriter textWriter = new StringWriter())
		{
			serializer.Serialize(textWriter, xc);
			result = textWriter.ToString();
		}
	}
    public class XsdClass 
	{
		public string SomeString1 { get; set; }
		public string SomeString2 { get; set; }
		public string SomeString3 { get; set; }
	}
