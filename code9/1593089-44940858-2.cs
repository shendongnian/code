            public class SocketMiddleware
        {
    		private static ConcurrentDictionary<string, SocketMiddleware> _activeConnections = new ConcurrentDictionary<string, SocketMiddleware>();
    		private string _packet;
    
    		private ManualResetEvent _send = new ManualResetEvent(false);
    		private ManualResetEvent _exit = new ManualResetEvent(false);
    		private readonly RequestDelegate _next;
    
    		public SocketMiddleware(RequestDelegate next)
    		{
    			_next = next;
    		}
    
    		public void Send(string data)
    		{
    			_packet = data;
    			_send.Set();
    		}
    
    		public async Task Invoke(HttpContext context)
    		{
    			if (context.WebSockets.IsWebSocketRequest)
    			{    
    				string connectionName = context.Request.Query["connectionName"]);
    				if (!_activeConnections.Any(ac => ac.Key == connectionName))
    				{
    				    WebSocket socket = await context.WebSockets.AcceptWebSocketAsync();
    				    if (socket == null || socket.State != WebSocketState.Open)
    				    {
    					    await _next.Invoke(context);
    					    return;
    				    }
    					Thread sender = new Thread(() => StartSending(socket));
    					sender.Start();
    
    					if (!_activeConnections.TryAdd(connectionName, this))
    					{
    						_exit.Set();
    						await _next.Invoke(context);
    						return;
    					}
    
    					while (true)
    					{
    						WebSocketReceiveResult result = socket.ReceiveAsync(new ArraySegment<byte>(new byte[1]), CancellationToken.None).Result;
    						if (result.CloseStatus.HasValue)
    						{
    							_exit.Set();
    							break;
    						}
    					}
    
    					SocketHandler dummy;
    					_activeConnections.TryRemove(key, out dummy);
    				}
    			}
    
    			await _next.Invoke(context);
    
    			string data = context.Items["Data"] as string;
    			if (!string.IsNullOrEmpty(data))
    			{
                    string name = context.Items["ConnectionName"] as string;
    				SocketMiddleware connection = _activeConnections.Where(ac => ac.Key == name)?.Single().Value;
    				if (connection != null)
    				{
    					connection.Send(data);
    				}
    			}
    		}
    
    		private void StartSending(WebSocket socket)
    		{
    			WaitHandle[] events = new WaitHandle[] { _send, _exit };
    			while (true)
    			{
    				if (WaitHandle.WaitAny(events) == 1)
    				{
    					break;
    				}
    
    				if (!string.IsNullOrEmpty(_packet))
    				{
    					SendPacket(socket, _packet);
    				}
    				_send.Reset();
    			}
    		}
    
    		private void SendPacket(WebSocket socket, string packet)
    		{
    			byte[] buffer = Encoding.UTF8.GetBytes(packet);
    			ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
    			Task.Run(() => socket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None));
    		}
    	}
