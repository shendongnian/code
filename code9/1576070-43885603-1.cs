    public abstract class Command
    {
    	protected Command()
    	{
    	}
    
    	public abstract string Execute(object o = null);
    }
