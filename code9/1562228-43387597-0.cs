    public class Parent
    {
    	public interface INested
    	{
    	}
    	private class Nested : INested
    	{
    		public Nested()
    		{
    		}
    	}
    
    	public INested Foo()
    	{
    		Nested n = new Nested();
    		// do something about n
    		return n;
    	}
    }
