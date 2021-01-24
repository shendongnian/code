    class LogGroup
    {
    	static bool ReferenceActiveGroups = true; //I'm not sure if this is needed. It might work fine without.
    	static HashSet<LogGroup> LogGroups = ReferenceActiveGroups ? new HashSet<LogGroup>() : null;
    
    	/// <summary>
    	/// For the currently being ran query, this outputs the Raw SQL and the length of time it was executed in the Output window (CTRL + ALT + O) when in Debug mode.
    	/// </summary>
    	/// <param name="db">The DbContext to be outputted in the Output Window.</param>
    	public static void Log(ApiController context, AppContext db)
    	{
    		var o = new LogGroup(context, db);
    		o.Initialise();
    		if (ReferenceActiveGroups) o.Add();
    	}
    
    	public LogGroup(ApiController context, AppContext db)
    	{
    		this.context = context;
    		this.db = db;
    	}
    
    	public void Initialise()
    	{
    		db.OnDisposed += (sender, e) => { this.Complete(); };
    		db.Database.Log = this.Handler;
    
    		sb.AppendLine("LOG GROUP START");
    	}
    
    	public void Add()
    	{
    		lock (LogGroups)
    		{
    			LogGroups.Add(this);
    		}
    	}
    
    	public void Handler(string message)
    	{
    		sb.AppendLine(message);
    	}
    
    	public AppContext db = null;
    	public ApiController context = null;
    	public StringBuilder sb = new StringBuilder();
    
    	public void Remove()
    	{
    		lock (LogGroups)
    		{
    			LogGroups.Remove(this);
    		}
    	}
    
    	public void Complete()
    	{
    		if (ReferenceActiveGroups) Remove();
    
    		sb.AppendLine("LOG GROUP END");
    		System.Diagnostics.Debug.WriteLine(sb.ToString());
    	}
    }
