    // Location to store file so we can access the data.
    var tempFile = Path.GetTempFileName();
    try {
        // Save attachment into our file
    	mail.Attachments[i].SaveToFile(tempFile);
    	
    	using(var stream = File.OpenRead(tempFile)) {
    		// Do stuff
    	}
    } finally {
        // Cleanup the temp file
    	File.Delete(tempFile);
    }
