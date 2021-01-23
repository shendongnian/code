    internal class MessageReader : IDisposable
    {
    	private MessageBuffer buffer;
    	private Message message;
    
    	private void Release()
    	{
    		if (buffer == null) return;
    		buffer.Close();
    		buffer = null;
    		message = null;
    	}
    
    	protected void OnReadRequest(ref Message message)
    	{
    		if (message == null) throw new ArgumentNullException("message");
    		if (this.message == message) return;
    		Release();
    		this.buffer = message.CreateBufferedCopy(int.MaxValue);
    		message = this.message = buffer.CreateMessage();
    	}
    
    	public void Dispose()
    	{
    		Release();
    	}
    
    	internal string ReadSomething(ref Message message, string id)
    	{
    		OnReadRequest(ref message);
    		// Return string
    	}
    
    	internal string ReadSomethingElse(ref Message message, string id)
    	{
    		OnReadRequest(ref message);
    		// Return string
    	}
    }
