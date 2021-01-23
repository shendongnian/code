    public class MyStream : IDisposable
    {
    	private string name;
    	private Stream stream;
    
    	public MyStream(string name)
    	{
    		this.Name = name;
    		this.Stream = new FileStream(...);
    	}
    
    	public string Name
    	{
    		get
    		{
    			return this.name;
    		}
    	}
    	
    	public Stream Stream
    	{
    		get
    		{
    			if (this.IsDisposed)
    			{
    				throw new ObjectDisposedException();
    			}
    			
    			return this.stream;
    		}
    	}
    	
    	private bool IsDisposed { get; set; }
    	
    	public void Dispose()
    	{
    		if (!this.IsDisposed)
    		{
    			this.IsDisposed = true;
    			this.Stream.Dispose();
    			this.Stream = null;
    		}
    	}
    }
