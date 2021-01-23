     <summary>
    /// Handler for an incoming websocket client
    /// </summary>
    public class WSHandler {
        /// <summary>
        /// Max size in bytes of an incoming/outgoing message
        /// </summary>
        public const int BufferSize = 4096;
    
        /// <summary>
        /// The socket of the current connection
        /// </summary>
        WebSocket socket;
    
        /// <summary>
        /// The options to create DbContexts with.
        /// </summary>
        DbContextOptions<AssemblyServerContext> ctxOpts;
    
        /// <summary>
        /// Constructor, assign socket to current instance and adds socket to ConnectedClients. 
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="ctxOpts"></param>
        WSHandler(WebSocket socket, DbContextOptions<AssemblyServerContext> ctxOpts) {
            this.ctxOpts = ctxOpts;
            this.socket = socket;
        }
    
        /// <summary>
        /// Configure app to use websockets and register handler.
        /// </summary>
        /// <param name="app"></param>
        public static void Map(IApplicationBuilder app) {
            app.UseWebSockets();
            app.Use((WSHandler.Acceptor);
        }
    
        /// <summary>
        /// Accept HttpContext and handles constructs instance of WSHandler.
        /// </summary>
        /// <param name="hc">The HttpContext</param>
        /// <param name="n">Task n</param>
        /// <returns></returns>
        static async Task Acceptor(HttpContext hc, Func<Task> n) {
             if (hc.WebSockets.IsWebSocketRequest == false) {
                return; 
            }
    
            var socket = await hc.WebSockets.AcceptWebSocketAsync();
            var ctxOptions = hc.RequestServices.GetService<DbContextOptions<AssemblyServerContext>>();
            var h = new WSHandler(socket, ctxOptions);
            await h.Loop();
        }
    
        /// <summary>
        /// Wait's for incoming messages 
        /// </summary>
        /// <returns></returns>
        async Task Loop() {
            var buffer = new Byte[BufferSize];
            ArraySegment<Byte> segment = new ArraySegment<byte>(buffer);
            while (this.socket.State == WebSocketState.Open) {
                WebSocketReceiveResult result = null;
                do {
                    result = await socket.ReceiveAsync(segment, CancellationToken.None);
                } while (result.EndOfMessage == false);
    
                // do something with message here. I want to save parse and save to database
                using (var ctx = new AssemblyServerContext(ctxOpts)) {
    
                }
            }
    
        }
    }
