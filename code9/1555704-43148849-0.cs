    public class ArrayItemComparer : IComparer<string>
    {
    	public int Compare(string x, string y)
    	{
    		int xInt = 0, yInt = 0;
    
    		bool parseX = int.TryParse(x, out xInt);
    		bool parseY = int.TryParse(y, out yInt);
    
    		if (parseX && parseY)
    		{
    			return xInt.CompareTo(yInt);
    		}
    		else if (parseX)
    		{
    			return -1;
    		}
    		else if (parseY)
    		{
    			return 1;
    		}
    		else
    		{
    			return x.CompareTo(y);
    		}
    	}
    }
