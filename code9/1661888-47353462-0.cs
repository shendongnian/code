    using System;
    using System.IO;
    using System.Net;
    using System.Web;
    using System.Net.Http;
    using System.Web.Http;
    using AForge.Video;
    using System.Drawing;
    using System.Text;
    using System.Drawing.Imaging;
    using System.Threading;
    namespace VideoPrototypeMVC.Controllers
    {
        public class CameraController : ApiController
        {
            private MJPEGStream mjpegStream = new MJPEGStream();
            private bool frameAvailable = false;
            private Bitmap frame = null;
            private string BOUNDARY = "frame";
            /// <summary>
            /// Initializer for the MJPEGstream
            /// </summary>
            CameraController()
            {
                mjpegStream.Source = @"{{INSERT STREAM URL}}";
                mjpegStream.NewFrame += new NewFrameEventHandler(showFrameEvent);
            }
            [HttpGet]
            public HttpResponseMessage GetVideoContent()
            {   
                mjpegStream.Start();
                var response = Request.CreateResponse();
                response.Content = new PushStreamContent((Action<Stream, HttpContent, TransportContext>)StartStream);
                response.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("multipart/x-mixed-replace; boundary=" + BOUNDARY);
                return response;
            }
            /// <summary>
            /// Craete an appropriate header.
            /// </summary>
            /// <param name="length"></param>
            /// <returns></returns>
            private byte[] CreateHeader(int length)
            {
                string header =
                    "--" + BOUNDARY + "\r\n" +
                    "Content-Type:image/jpeg\r\n" +
                    "Content-Length:" + length + "\r\n\r\n";
                return Encoding.ASCII.GetBytes(header);
            }
            public byte[] CreateFooter()
            {
                return Encoding.ASCII.GetBytes("\r\n");
            }
            /// <summary>
            /// Write the given frame to the stream
            /// </summary>
            /// <param name="stream">Stream</param>
            /// <param name="frame">Bitmap format frame</param>
            private void WriteFrame(Stream stream, Bitmap frame)
            {
                // prepare image data
                byte[] imageData = null;
                // this is to make sure memory stream is disposed after using
                using (MemoryStream ms = new MemoryStream())
                {
                    frame.Save(ms, ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }
                // prepare header
                byte[] header = CreateHeader(imageData.Length);
                // prepare footer
                byte[] footer = CreateFooter();
                // Start writing data
                stream.Write(header, 0, header.Length);
                stream.Write(imageData, 0, imageData.Length);
                stream.Write(footer, 0, footer.Length);
            }
            /// <summary>
            /// While the MJPEGStream is running and clients are connected,
            /// continue sending frames.
            /// </summary>
            /// <param name="stream">Stream to write to.</param>
            /// <param name="httpContent">The content information</param>
            /// <param name="transportContext"></param>
            private void StartStream(Stream stream, HttpContent httpContent, TransportContext transportContext)
            {
                while (mjpegStream.IsRunning && HttpContext.Current.Response.IsClientConnected)
                {
                    if (frameAvailable)
                    {
                        try
                        {
                            WriteFrame(stream, frame);
                            frameAvailable = false;
                        } catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e);
                        }
                    }else
                    {
                        Thread.Sleep(30);
                    }
                }
                stopStream();
            }
            /// <summary>
            /// This event is thrown when a new frame is detected by the MJPEGStream
            /// </summary>
            /// <param name="sender">Object that is sending the event</param>
            /// <param name="eventArgs">Data from the event, including the frame</param>
            private void showFrameEvent(object sender, NewFrameEventArgs eventArgs)
            {
                frame = new Bitmap(eventArgs.Frame);
                frameAvailable = true;
            }
            /// <summary>
            /// Stop the stream.
            /// </summary>
            private void stopStream()
            {
                System.Diagnostics.Debug.WriteLine("Stop stream");
                mjpegStream.Stop();
            }
        }
    }
