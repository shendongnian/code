    public interface IPosition
    {
    	int ID { get; set; }
    }
    public class RealPosition : IPosition
    {
    	public int ID { get; set; }
    }
    
    public class AccessiblePosition : IPosition
    {
    	public int ID { get; set; }
    }
    void Main()
    {
    	var toReplace = new RealPosition { ID = 1 };		
    	var list1 = new List<IPosition>
    	{
    		toReplace,
    		new RealPosition { ID = 2 },
    		new RealPosition { ID = 3 },
    	};
    	var list2 = new List<IPosition>
    	{
    		toReplace,
    		new RealPosition { ID = 4 },
    		new RealPosition { ID = 5 },
    	};
    	var listOfLists = new List<List<IPosition>>{ list1, list2 };
    	var replacement = new AccessiblePosition{ ID = 42 };
    	
    	foreach(var list in listOfLists)
    	{
            //must use for here
    		for(int i = 0; i < list.Count; ++i)
    		{
    			if(list[i] == toReplace)
    			{						
    				list[i] = replacement;
    			}
    		}
    	}
    }
