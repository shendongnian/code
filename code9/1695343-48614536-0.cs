	byte[] authTag = encryptor.GetTag();
	
	using (var tempfile = File.OpenRead(BUFER_PATH))
	using (var outstream = File.Create(END_PATH))
	{
		// write tag
		outstream.Write(authTag, 0, authTag.Length);
		// write IV
		outstream.Write(aes.IV, 0, aes.IV.Length);
		// copy data from source file to output file
		tempfile.CopyTo(outstream);
	}
