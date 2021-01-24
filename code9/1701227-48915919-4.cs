    class Program
    {
        private static Server.WebsocketServer websocketServer;
        private static System.Diagnostics.EventLog eventLog1= new EventLog();
        static void Main( string[] args )
        {
            if (!System.Diagnostics.EventLog.SourceExists( "MySource" ))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyNewLog" );
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
            
            websocketServer = new Server.WebsocketServer();
            websocketServer.LogMessage += WebsocketServer_LogMessage; 
            websocketServer.Start( "http://localhost:2645/tryservice/" );
            Console.Read();
        }
        private static void WebsocketServer_LogMessage( object sender, Server.WebsocketServer.LogMessageEventArgs e )
        {
            // eventLog1.WriteEntry( e.Message );
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine( e.Message );
            Console.ForegroundColor = ConsoleColor.White;
        }
    public  class WebsocketServer
    {
        public event OnLogMessage LogMessage;
        public delegate void OnLogMessage(Object sender, LogMessageEventArgs e);
        public class LogMessageEventArgs : EventArgs
        {
            public string Message { get; set; }
            public LogMessageEventArgs(string Message) {
                this.Message = Message;
            }
        }
        public bool started = false;
        public async void Start(string httpListenerPrefix)
        {
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add(httpListenerPrefix);
            httpListener.Start();
            LogMessage(this, new LogMessageEventArgs("Listening..."));
            started = true;
            while (started)
            {
                HttpListenerContext httpListenerContext = await httpListener.GetContextAsync();
                if (httpListenerContext.Request.IsWebSocketRequest)
                {
                    ProcessRequest(httpListenerContext);
                }
                else
                {
                    httpListenerContext.Response.StatusCode = 400;
                    httpListenerContext.Response.Close();
                    LogMessage(this, new LogMessageEventArgs("Closed..."));
                }
            }
        }
        public void Stop()
        {
            started = false;
        }
        private List<string> _printers = new List<string>();
        public List<string> Printers { get
            {
                _printers.Clear();
                foreach (string imp in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    _printers.Add(imp);
                }
                return _printers;
            }
        }
        private async void ProcessRequest(HttpListenerContext httpListenerContext)
        {
            WebSocketContext webSocketContext = null;
            
            try
            {
                webSocketContext = await httpListenerContext.AcceptWebSocketAsync(subProtocol: null);
                LogMessage(this, new LogMessageEventArgs("Connected"));
            }
            catch (Exception e)
            {
                httpListenerContext.Response.StatusCode = 500;
                httpListenerContext.Response.Close();
                LogMessage(this, new LogMessageEventArgs(String.Format("Exception: {0}", e)));
                return;
            }
            WebSocket webSocket = webSocketContext.WebSocket;
            try
            {
               
                while (webSocket.State == WebSocketState.Open)
                {
                    ArraySegment<Byte> buffer = new ArraySegment<byte>(new Byte[8192]);
                    WebSocketReceiveResult result = null;
                    using (var ms = new System.IO.MemoryStream())
                    {
                        do
                        {
                            result = await webSocket.ReceiveAsync(buffer, CancellationToken.None);
                            ms.Write(buffer.Array, buffer.Offset, result.Count);
                        }
                        while (!result.EndOfMessage);
                        ms.Seek(0, System.IO.SeekOrigin.Begin);
                        if (result.MessageType == WebSocketMessageType.Text)
                        {
                            using (var reader = new System.IO.StreamReader(ms, Encoding.UTF8))
                            {
                                var r = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                                var t = Newtonsoft.Json.JsonConvert.DeserializeObject<Datos>(r);
                                bool valid = true;
                                byte[] toBytes = Encoding.UTF8.GetBytes("Error..."); ;
                                if (t != null)
                                {
                                    if (t.Impresora.Trim() == string.Empty)
                                    {
                                        var printers = "";
                                        Printers.ForEach(print => {
                                            printers += print + "\n";
                                        });
                                                                                  
                                        toBytes = Encoding.UTF8.GetBytes("No se Indicó la Impresora\nLas Impresoras disponibles son:\n" + printers);
                                        valid = false;
                                    }
                                    else if(!Printers.Contains(t.Impresora))
                                    {
                                        var printers = "";
                                        Printers.ForEach(print =>
                                        {
                                            printers += print + "\n";
                                        });
                                        toBytes = Encoding.UTF8.GetBytes("Impresora no valida\nLas Impresoras disponibles son:\n" + printers);
                                        valid = false;
                                    }
                                    if (t.nombre.Trim() == string.Empty)
                                    {
                                        toBytes = Encoding.UTF8.GetBytes("No se Indicó el nombre del Documento");
                                        valid = false;
                                    }
                                    if (t.code== null)
                                    {
                                        toBytes = Encoding.UTF8.GetBytes("No hay datos para enviar a la Impresora");
                                        valid = false;
                                    }
                                    if (valid && print.RawPrinter.SendStringToPrinter(t.Impresora, t.code, t.nombre))
                                    {
                                        LogMessage(this, new LogMessageEventArgs(String.Format("Enviado: {0} => {1} => {2}", t.Impresora, t.nombre, t.code)));
                                        toBytes = Encoding.UTF8.GetBytes("Correcto...");
                                    }
                                    await webSocket.SendAsync(new ArraySegment<byte>(toBytes, 0, int.Parse(toBytes.Length.ToString())), WebSocketMessageType.Binary, result.EndOfMessage, CancellationToken.None);
                                }
                                else
                                {
                                    toBytes = Encoding.UTF8.GetBytes("Error...");
                                    await webSocket.SendAsync(new ArraySegment<byte>(toBytes, 0, int.Parse(toBytes.Length.ToString())), WebSocketMessageType.Binary, result.EndOfMessage, CancellationToken.None);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogMessage(this, new LogMessageEventArgs(String.Format("Exception: {0} \nLinea:{1}", e, e.StackTrace)));
            }
            finally
            {
                if (webSocket != null)
                    webSocket.Dispose();
            }
        }
    }
    public class Datos {
        public enum TipoArchivo { zpl, pdf, doc, json, text}
        public string nombre { get; set; }
        public string code { get; set; }
        public TipoArchivo Tipo { get; set; } = TipoArchivo.text;
        public string Impresora { get; set; } = "";
    }
    }
