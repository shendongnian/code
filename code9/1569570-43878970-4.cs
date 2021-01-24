    public string Serializador<T>(T objeto, XmlAttributeOverrides overrides = null)
    {
    	string xml = string.Empty;
    	using (var sw = new ISO8859StringWriter())
    	{
    		XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    		ns.Add("", ""); // to omit XML namespaces
    		var xs = new XmlSerializer(typeof(T), overrides);
    		xs.Serialize(sw, objeto, ns);
    		xml = sw.ToString();
    	}
    	return xml;
    }
