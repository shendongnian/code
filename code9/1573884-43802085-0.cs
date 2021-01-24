	public Stream DownloadToStream(string url)
	{
	    using (var webClient = new System.Net.WebClient())
	    {
	        byte[] data = webClient.DownloadData(url);
	        var ms = new System.IO.MemoryStream(data);
	        return ms;
	    }
	}
