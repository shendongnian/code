    byte[] ObjectToByteArray(object obj)
	byte[] ObjectToByteArray(object obj)
	{
		if(obj == null)
			return null;
		BinaryFormatter bf = new BinaryFormatter();
		using (MemoryStream ms = new MemoryStream())
		{
			bf.Serialize(ms, obj);
			return ms.ToArray();
		}
	}
	object ByteArrayToObject(byte[] buffer)
	{
		MemoryStream ms = new MemoryStream (buffer);
		BinaryFormatter bf = new BinaryFormatter ();
		return bf.Deserialize (ms);
	}
