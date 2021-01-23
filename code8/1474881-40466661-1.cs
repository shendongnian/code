    public class CustomHttpPostedFile : HttpPostedFileBase
    {
    	[JsonProperty("ContentLength")]
    	private int contentLength;
    	[JsonProperty("FileName")]
    	private string fileName;
    	[JsonProperty("ContentType")]
    	private string contentType;
    	[JsonProperty("InputStream")]
    	private Stream inputStream;
    	[JsonIgnore]
    	public override int ContentLength { get { return contentLength; } }
    	[JsonIgnore]
    	public override string FileName { get { return fileName; } }
    	[JsonIgnore]
    	public override string ContentType { get { return contentType; } }
    	[JsonIgnore]
    	public override Stream InputStream { get { return inputStream; } }
    	public override void SaveAs(string filename)
    	{
    		using (var output = File.Create(fileName))
    			InputStream.CopyTo(output);
    	}
    }
