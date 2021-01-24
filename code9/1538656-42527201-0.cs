    //Create a random, new guid
	Guid guid = Guid.NewGuid();
	Console.WriteLine(guid);
		
    //The original bytes
	byte[] guidBytes = guid.ToByteArray();
    //Your custom bytes
	byte[] first4Bytes = BitConverter.GetBytes((UInt32) 0815);
		
	//Overwrite the first 4 Bytes
	Array.Copy(first4Bytes, guidBytes, 4);
		
	//Create new guid based on current values
	Guid guid2 = new Guid(guidBytes);
	Console.WriteLine(guid2);
