    using (HMACSHA256 hmac = new HMACSHA256(key)) // Initialize the keyed hash object.
    {
    	using (FileStream inStream = new FileStream(sourceFile, FileMode.Open))
    	{
    		using (FileStream outStream = new FileStream(destFile, FileMode.Create))
    		{
    			byte[] hashValue = hmac.ComputeHash(inStream); // Compute the hash of the input file.
    			outStream.Write(hashValue, 0, hashValue.Length); // Write the computed hash value to the output file.
    
    			inStream.Position = 0;
    			int bytesRead;
    			byte[] buffer = new byte[1024];
    			do
    			{
    				bytesRead = inStream.Read(buffer, 0, 1024);
    				outStream.Write(buffer, 0, bytesRead);
    			} while (bytesRead > 0);
    
    		}
    	}
    }
