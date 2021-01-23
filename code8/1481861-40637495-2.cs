    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Drawing;
    
    namespace WebApplication1 /*use your application namespace*/
    {
        public class ImageHandler: IHttpHandler
        {
            public void ProcessRequest(HttpContext context)
            {
                int width = 0;
                int.TryParse(context.Request.QueryString["width"], out width);
                var height = 0;
                int.TryParse(context.Request.QueryString["height"], out height);
                if (width <= 0) width = 100;
                if (height <= 0) height = 100;
                using (var image = new Bitmap(width, height))
                {
                    using (var g = Graphics.FromImage(image))
                        g.Clear(Color.Red);
                    byte[] buffer = 
                        (byte[])new ImageConverter().ConvertTo(image, typeof(byte[]));
                    context.Response.ContentType = "image/bmp";
                    context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                }
            }
            public bool IsReusable { get { return false; } }
        }
    }
