    public class WebSocketsSingleton
    {
    	private static WebSocketsSingleton _instance = null;
    	//here stored web sockets groupped by user
    	//you could use user Id or another marker to exactly determine the user
    	private Dictionary<string, List<WebSocket>> _connectedSockets;
    	
    	//for a thread-safety usage
    	private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();
    		
    	public static WebSocketsSingleton Instance {
    		get {
    			if (this._instance == null)
    			{
    				this._instance = new WebSocketsSingleton();
    			}
    			
    			return this._instance;
    		}
    	}
    	
    	private WebSocketsSingleton()
    	{
    		this._connectedSockets = new Dictionary<string, List<WebSocket>>();
    	}
    	
    	/// <summary>
    	/// Adds a socket into the required collection
    	/// </summary>
    	public void AddSocket(string userName, WebSocket ws)
    	{
    		if (!this._connectedSockets.ContainsKey(userName))
    		{
    			Locker.EnterWriteLock();
    			try
    			{
    				this._connectedSockets.Add(userName, new List<WebSocket>());
    			}
    			finally
    			{
    				Locker.ExitWriteLock();
    			}
    		}
    		
    		Locker.EnterWriteLock();
    		try
    		{
    			this._connectedSockets[userName].Add(ws);
    		}
    		finally
    		{
    			Locker.ExitWriteLock();
    		}
    	}
    
    	/// <summary>
    	/// Sends a UI command to required user
    	/// </summary>	
    	public async Task<string> SendAsync(string userName, UICommand command)
    	{
    		if (this._connectedSockets.ContainsKey(userName))
    		{
    			var sendData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(command));
    			
			foreach(var item in this._connectedSockets[userName])
			{
				try
				{
					await item.SendAsync(new ArraySegment<byte>(sendData), WebSocketMessageType.Text, true, CancellationToken.None);
				}
				catch (ObjectDisposedException)
				{
					//socket removed from front end side
				}
			}
    			
    			var buffer = new ArraySegment<byte>(new byte[1024]);
    			var token = CancellationToken.None;			
    			foreach(var item in this._connectedSockets[userName])
    			{
    				await Task.Run(async () => {
    					var tempResult = await item.ReceiveAsync(buffer, token);
    					//result received
    					token = new CancellationToken(true);
    				});
    			}
    			
    			var resultStr = Encoding.Utf8.GetString(buffer.Array);
    			
    			if (command.ReturnType == typeof(bool))
    			{
    				return resultStr.ToLower() == "true";
    			}
    			
    			//other methods to convert result into required type
    			
    			return resultStr;
    		}
    		
    		return null;
    	}
    }
