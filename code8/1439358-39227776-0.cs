    [Route("api/{slip}")]
    [HttpGet]
    public async Task<IHttpActionResult> TrackJob(String slip)
    {
        var serverEndpoint = string.Format("ws://{0}/api/services", slip);
        HttpContext currentContext = HttpContext.Current;
        if (currentContext.IsWebSocketRequest)
        {
            try
            {
                currentContext.AcceptWebSocketRequest(GetWebSocketSession(serverEndpoint));
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.SwitchingProtocols));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        else
        {
            return NotFound();
        }
    }
    private Func<AspNetWebSocketContext, Task> GetWebSocketSession(String serverEndpoint)
    {
        Func<AspNetWebSocketContext, Task> func = async (context) =>
        {
            var wsToClient = context.WebSocket;
            using (var wsToProcessingCluster = new ClientWebSocket())
            { 
                new Task(async () =>
                {
                    var inputSegment = new ArraySegment<byte>(new byte[1024]);
                    while (true)
                    {
                        // MUST read if we want the state to get updated...
                        try
                        {
                            await wsToClient.ReceiveAsync(inputSegment, CancellationToken.None);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            return;
                        }
                        if (wsToClient.State != WebSocketState.Open)
                        {
                            await wsToProcessingCluster.CloseAsync(WebSocketCloseStatus.Empty, "", CancellationToken.None);
                            break;
                        }
                    }
                }).Start();
                var buffer = new byte[1024];
                var uri = new Uri(serverEndpoint);
                await wsToProcessingCluster.ConnectAsync(uri, CancellationToken.None);
                while (true)
                {
                    if (wsToClient.State != WebSocketState.Open)
                    {
                        break;
                    }
                    else
                    {
                        var segment = new ArraySegment<byte>(buffer);
                        var result = await wsToProcessingCluster.ReceiveAsync(segment, CancellationToken.None);
                        await wsToClient.SendAsync(segment, result.MessageType, result.EndOfMessage, CancellationToken.None);
                    }
                }
            }
        };
        return func;
    }
