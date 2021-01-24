	private void PageLoad(object sender, System.EventArgs e)
	{
		System.IO.MemoryStream mstream = createDocument();
		byte[] byteArray = mstream.ToArray();
		mstream.Flush();
		mstream.Close();
		Response.Clear();
		// Add a HTTP header to the output stream that specifies the default filename
		// for the browser's download dialog
		Response.AddHeader("Content", "attachment; filename=foo.docx");
		// Add a HTTP header to the output stream that contains the 
		// content length(File Size). This lets the browser know how much data is being transfered
		Response.AddHeader("Content", byteArray.Length.ToString());
		// Set the HTTP MIME type of the output stream
		Response.ContentType = "application/octet-stream";
		// Write the data out to the client.
		Response.BinaryWrite(byteArray);
	}
