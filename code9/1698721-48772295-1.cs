        [ActionName("GetImage")]
        [HttpGet]
        public HttpResponseMessage GetImage(string parameter)
        {
            using (Bitmap icon = new Bitmap(500, 100))
            {
            
                Graphics g = Graphics.FromImage(icon);
                RectangleF rectf = new RectangleF(10,10,480,80);
                g.DrawString("Hello World!", new Font("Tahoma", 20), Brushes.White, rectf);
                g.Flush();
                HttpResponseMessage responseMessage = Request.CreateResponse();
                MemoryStream memStream = new MemoryStream();
                icon.Save(memStream, ImageFormat.Bmp);
                memStream.Position = 0;
                responseMessage.Content = new StreamContent(memStream);
                responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("image/bmp");
                return responseMessage;
            }
        }
