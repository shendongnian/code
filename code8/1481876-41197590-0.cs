    public class TrackedOleDbConnection: OleDbConnection
    {
    	public TrackedOleDbConnection() : base()
    	{
    	}
    	
    	public TrackedOleDbConnection(string ConnectionString) : base(ConnectionString)
    	{
    	}
    	
    	//You don't need to create a constructor for every overload of the baseclass, only for overloads your project uses
    	ConcurrentList<TrackedOleDbConnection> ActiveConnections = new ConcurrentList<TrackedOleDbConnection>();
    	void AddActiveConnection()
    	{
    		ActiveConnections.Add(this);
    	}
    	
    	override void Dispose()
    	{
    		ActiveConnections.RemoveIfExists(this); //Pseudo-function
    		GC.SuppressFinalise(this);
    	}
    	
    	//Destructor, to ensure the ActiveConnection is always removed, if Dispose wasn't called
    	~TrackedOleDbConnection()
    	{
    		//TODO: You should log when this function runs, so you know you still have missing Dispose calls in your code, and then find and add them.
    		Dispose();
    	}
    }
