    public class Entity<TKey>
    {
    	public Entity(TKey k)
    	{
    
    	}
    
    }
    
    public static class Entity
    {
    	public static Entity<MyKey> Create<MyKey>(MyKey mk)
    	{
    		return new Entity<MyKey>(mk);
    	}
    }
