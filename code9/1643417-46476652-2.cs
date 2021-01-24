	static List<ApplicationLogEventObject> ReadEvents(string fileName)
	{
		return ReadObjects<ApplicationLogEventObject>(fileName);
	}
	
	static List<T> ReadObjects<T>(string fileName)
	{
		var list = new List<T>();
		
		var serializer = new XmlSerializer(typeof(T));
		var settings = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
		using (var textReader = new StreamReader(fileName))
		using (var xmlTextReader = XmlReader.Create(textReader, settings))
		{
            while (xmlTextReader.Read())
            {   // Skip whitespace
                if (xmlTextReader.NodeType == XmlNodeType.Element) 
                {
					using (var subReader = xmlTextReader.ReadSubtree())
					{
						var logEvent = (T)serializer.Deserialize(subReader);
						list.Add(logEvent);
					}
                }
            }
		}
		return list;			
	}
