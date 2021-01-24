    public abstract class Notes<T, TProperty> where T : Notes<T, TProperty>
    {
    	public abstract Expression<Func<T, TProperty>> OrderByField();
    
        public string GetOrderByFieldName()
        {
    	    //snip
        }
    }
    
    public class Message : Notes<Message, int>
    {
    	public int item_no { get; set; }
    	
    	public override Expression<Func<Message, int>> OrderByField()
    	{
    		return m => m.item_no;
    	}
    }
