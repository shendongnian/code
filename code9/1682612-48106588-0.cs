    public class ItemAGenerator : IGenerator
    {
    	public IList<IItem> Generate()
    	{
    		var list = new List<IItem>();
    		list.Add(new ItemA());
    		
    		return list;
    	}
    }
