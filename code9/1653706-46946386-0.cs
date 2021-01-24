    /// <summary>
    /// Summary description for ImageFormatter
    /// </summary>
    public class ImageFormatter
    {
    	public ImageFormatter()
    	{
    		//
    		// TODO: Add constructor logic here
    		//
    	}
    	
        public static string FormatImageUrl(string url)
        {
	    if (url != null && url.Length > 0)
		return ("~/" + url);
	    else return null;
	}
    }
