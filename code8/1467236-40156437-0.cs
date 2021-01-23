    public interface IUpdateHandler
    {
    	void UpdateHandler();
    }
    
    public class Base : IUpdateHandler
    {
    	public Base()
    	{
    		OnUpdate += (s, e) => UpdateHandler();
    	}
    
    	public void Update()
    	{
    		OnUpdate(this, null);
    	}
    
    	public void UpdateHandler()
    	{
    		Console.WriteLine("BASE UPDATE");
    	}
    
    	protected event EventHandler OnUpdate;
    }
    
    public class Base2 : Base, IUpdateHandler
    {
    	public Base2()
    	{
    		OnUpdate += (sender, args) => UpdateHandler();
    	}
    
    	public new void UpdateHandler()
    	{
    		Console.WriteLine("BASE2 UPDATE");
    	}
    }
    
    public class Base3 : Base2, IUpdateHandler
    {
    	public Base3()
    	{
    		OnUpdate += (sender, args) => UpdateHandler();
    	}
    
    	public new void UpdateHandler()
    	{
    		Console.WriteLine("BASE3 UPDATE");
    	}
    }
