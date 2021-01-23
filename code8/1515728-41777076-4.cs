    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.WebSockets;
    using System.Threading;
    using System.IO;
    using System.Drawing;
    using System.Collections.Concurrent;
    namespace TestServer
    {
    public class WebcamWebSocketServer : Nequeo.Net.WebSockets.WebSocketServer
    {
        /// <summary>
        /// 
        /// </summary>
        public WebcamWebSocketServer()
        {
            OnServerInitialise();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uriList"></param>
        public WebcamWebSocketServer(string[] uriList)
            : base(uriList)
        {
            OnServerInitialise();
        }
        int _clientCount = 0;
        private int READ_BUFFER_SIZE = 8192;
        private bool _stopCapture = false;
        private Nequeo.Media.FFmpeg.MediaDemux _demuxHttp = null;
        ConcurrentDictionary<System.Net.WebSockets.HttpListenerWebSocketContext, WebSocket> _clients = null;
        /// <summary>
        /// 
        /// </summary>
        private void OnServerInitialise()
        {
            base.Timeout = 60;
            base.HeaderTimeout = 30000;
            base.RequestTimeout = 30000;
            base.ResponseTimeout = 30000;
            base.Name = "Nequeo Web Socket Server";
            base.ServiceName = "WebSocketServer";
            base.OnWebSocketContext += WebSocketServer_OnWebSocketContext;
            _demuxHttp = new Nequeo.Media.FFmpeg.MediaDemux();
            // Open the web cam device.
            _demuxHttp.OpenDevice("video=Integrated Webcam", true, false);
            _clients = new ConcurrentDictionary<HttpListenerWebSocketContext, WebSocket>();
            // Start capture.
            CaptureAndSend();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="context"></param>
        private void WebSocketServer_OnWebSocketContext(object sender, System.Net.WebSockets.HttpListenerWebSocketContext context)
        {
            OnWebcamWebSocketContext(context);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private async void OnWebcamWebSocketContext(System.Net.WebSockets.HttpListenerWebSocketContext context)
        {
            WebSocket webSocket = null;
            try
            {
                // Get the current web socket.
                webSocket = context.WebSocket;
                CancellationTokenSource receiveCancelToken = new CancellationTokenSource();
                byte[] receiveBuffer = new byte[READ_BUFFER_SIZE];
                // While the WebSocket connection remains open run a 
                // simple loop that receives data and sends it back.
                while (webSocket.State == WebSocketState.Open)
                {
                    // Receive the next set of data.
                    ArraySegment<byte> arrayBuffer = new ArraySegment<byte>(receiveBuffer);
                    WebSocketReceiveResult receiveResult = await webSocket.ReceiveAsync(arrayBuffer, receiveCancelToken.Token);
                    // If the connection has been closed.
                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }
                    else
                    {
                        // Add the client 
                        _clients.GetOrAdd(context, webSocket);
                    }
                }
                // Cancel the receive request.
                if (webSocket.State != WebSocketState.Open)
                    receiveCancelToken.Cancel();
            }
            catch { }
            finally
            {
                // Clean up by disposing the WebSocket.
                if (webSocket != null)
                    webSocket.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private async void CaptureAndSend()
        {
            await System.Threading.Tasks.Task.Run(async () =>
            {
                byte[] sound = null;
                Bitmap[] image = null;
                long audioPos = 0;
                long videoPos = 0;
                int count = 0;
                KeyValuePair<HttpListenerWebSocketContext, WebSocket>[] clientCol = null;
                // Most of the time one image at a time.
                MemoryStream[] imageStream = new MemoryStream[10];
                int imageStreamCount = 0;
                // Within this loop you can place a check if there are any clients
                // connected, and if none then stop capturing until some are connected.
                while ((_demuxHttp.ReadFrame(out sound, out image, out audioPos, out videoPos) > 0) && !_stopCapture)
                {
                    imageStreamCount = 0;
                    count = _clients.Count;
                    // If count has changed.
                    if (_clientCount != count)
                    {
                        // Get the collection of all clients.
                        _clientCount = count;
                        clientCol = _clients.ToArray();
                    }
                    // Has an image been captured.
                    if (image != null && image.Length > 0)
                    {
                        // Get all clients and send.
                        if (clientCol != null)
                        {
                            for (int i = 0; i < image.Length; i++)
                            {
                                // Create a memory stream for each image.
                                imageStream[i] = new MemoryStream();
                                imageStreamCount++;
                                // Save the image to the stream.
                                image[i].Save(imageStream[i], System.Drawing.Imaging.ImageFormat.Jpeg);
                                // Cleanup.
                                image[i].Dispose();
                            }
                            // For each client.
                            foreach (KeyValuePair<HttpListenerWebSocketContext, WebSocket> client in clientCol)
                            {
                                // For each image captured.
                                for (int i = 0; i < imageStreamCount; i++)
                                {
                                    // data to send.
                                    byte[] result = imageStream[0].GetBuffer();
                                    string base64 = Convert.ToBase64String(result);
                                    byte[] base64Bytes = Encoding.Default.GetBytes(base64);
                                    try
                                    {
                                        // Send a message back to the client indicating that
                                        // the message was recivied and was sent.
                                        await client.Value.SendAsync(new ArraySegment<byte>(base64Bytes),
                                            WebSocketMessageType.Text, true, CancellationToken.None);
                                    }
                                    catch { }
                                    
                                    imageStream[i].Seek(0, SeekOrigin.Begin);
                                }
                            }
                            for (int i = 0; i < imageStreamCount; i++)
                                // Cleanup.
                                imageStream[i].Dispose();
                        }
                    }
                }
            });
        }
     }
     }
