   	/// <summary>
	/// Writes the collection to the specified Xml file
	/// </summary>
	/// <typeparam name="T">type of the object which collection contains</typeparam>
	/// <param name="objectToSave"></param>
	/// <param name="path">xml file path</param>
	public static void WriteXml<T>(this ICollection<T> objectToSave, string path) where T : class
	{
		// create an Xml Writer
		var writer = new System.Xml.Serialization.XmlSerializer(objectToSave.GetType());
		System.IO.StreamWriter file = new System.IO.StreamWriter(path);
		// Serialize the data
		writer.Serialize(file, objectToSave);
		// close the file
		file.Close();
	}
	public static ICollection<T> ReadXml<T>(this ICollection<T> objectToUse, string path) where T : class
	{
		try
		{
			// create the reader
			var reader = new System.Xml.Serialization.XmlSerializer(objectToUse.GetType());
			System.IO.StreamReader file = new System.IO.StreamReader(path);
			// Deserialize the data
			var data = reader.Deserialize(file);
			file.Close();
			if (data != null)
				return data as ICollection<T>;
		}
		catch (FileNotFoundException)
		{
		}
		return objectToUse;
	}
