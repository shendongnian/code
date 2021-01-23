    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.WebSockets;
    using System.Threading;
    using System.IO;
    using System.Drawing;
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
        private int READ_BUFFER_SIZE = 8192;
        private bool _stopCapture = false;
        private Nequeo.Media.FFmpeg.MediaDemux _demuxHttp = null;
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
                        byte[] sound = null;
                        Bitmap[] image = null;
                        long audioPos = 0;
                        long videoPos = 0;
                        // Most of the time one image at a time.
                        MemoryStream[] imageStream = new MemoryStream[10];
                        int imageStreamCount = 0;
                        // Within this loop you can place a check if there are any clients
                        // connected, and if none then stop capturing until some are connected.
                        while ((_demuxHttp.ReadFrame(out sound, out image, out audioPos, out videoPos) > 0) && !_stopCapture)
                        {
                            // Has an image been captured.
                            if (image != null && image.Length > 0)
                            {
                                // Create a memory stream for each image.
                                imageStream[0] = new MemoryStream();
                                imageStreamCount++;
                                // Save the image to the stream.
                                image[0].Save(imageStream[0], System.Drawing.Imaging.ImageFormat.Jpeg);
                                // data to send.
                                byte[] result = imageStream[0].GetBuffer();
                                string base64 = Convert.ToBase64String(result);
                                byte[] base64Bytes = Encoding.Default.GetBytes(base64);
                                // Send a message back to the client indicating that
                                // the message was recivied and was sent.
                                await webSocket.SendAsync(new ArraySegment<byte>(base64Bytes),
                                    WebSocketMessageType.Text, true, CancellationToken.None);
                                // Cleanup.
                                image[0].Dispose();
                                imageStream[0].Dispose();
                            }
                        }
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
    }
    }
