    private static T GetXmlFromFile<T>(string filename) {
		XmlSerializer xs = new XmlSerializer(typeof(T));
		using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
		{
			return (T)xs.Deserialize(fs);
		}
	}
