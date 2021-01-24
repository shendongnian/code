    void Main()
    {
    	using (var client = new WebClient())
    	{
    		client.Headers.Add("accept", "*/*");
    		byte[] filedata = client.DownloadData("http://members.tsetmc.com/tsev2/excel/MarketWatchPlus.aspx?d=1396-08-08");
    
    		using (MemoryStream ms = new MemoryStream(filedata))
    		{    
    			using (FileStream decompressedFileStream = File.Create("c:\\deleteme\\test.xlsx"))
    			{
    				using (GZipStream decompressionStream = new GZipStream(ms, CompressionMode.Decompress))
    				{
    					decompressionStream.CopyTo(decompressedFileStream);
    				}
    			}
    		}
    	}
    }
