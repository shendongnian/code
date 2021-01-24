    public string Upload(Stream data)
    {
    	MultipartParser parser = new MultipartParser(data);
    
    	if (parser.Success)
    	{
    	         // Save the file
                string filename = parser.Filename;
                string contentType = parser.ContentType;
                byte[] filecontent = parser.FileContents;
                File.WriteAllBytes(@"C:\test1.jpg", filecontent);
             }
      	return "OK";
    }
