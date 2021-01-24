    public class FwVersion
    {
    	public int Version;
    }
    
    public abstract class TechObject
        {
            public FwVersion FwVersion { get; set; }
        }
    
    public partial class PositioningAxis : TechObject
    {
        private int Drive_V3
        {
            get; set;
        }
        private int Drive_V4
        {
            get; set;
        }
    	
    	public int Drive
    	{
    		get
    		{
    			switch (this.FwVersion.Version)
    			{
    				case 3: return Drive_V3;
    				case 4: return Drive_V4;
    				default: return -1;
    			}
    		}
    		set 
    		{
    			switch (this.FwVersion.Version)
    			{
    				case 3: Drive_V3 = value;
    					break;
    				case 4: Drive_V4 = value;
    					break;
    			}
    		}
    	}
    }
