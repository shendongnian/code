    public class Basemap
    {
    	private string bmfilename;
    	private string bmdesc;
    	public Basemap(string filename, string desc)
    	{
    		this.bmfilename = filename;
    		this.bmdesc = desc;
    	}
    	public string BMFileName
    	{
    		get
    		{
    			return bmfilename;
    		}
    		set
    		{
    			bmfilename = value;
    		}
    	}
    	public string BMDesc
    	{
    		get
    		{
    			return bmdesc;
    		}
    		set
    		{
    			bmdesc = value;
    		}
    	}
    }
