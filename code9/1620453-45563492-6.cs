    public class Builder
    {
    	// Builder will have access to all fields of implementation 
    	// which will be hidden from other part of code
    	private ImplThinger1 ImplThinger1;
    	// other Thinger implementations
    	
    	public IThinger1 AddThing1()
    	{
    		return ImplThinger1 ?? (ImplThinger1 = new ImplThinger1());
    	}
    }
    
    public interface IThinger1
    {
    	void AddServiceReqThing1();
    }
    
    public class ImplThinger1 : IThinger1
    {
    	// accessible in builder and not outside 
    	// if it's not created outside
    	public Thing Data { get; }
    
    	public void AddServiceReqThing1()
    	{
    		// Stuff
    	}
    }
