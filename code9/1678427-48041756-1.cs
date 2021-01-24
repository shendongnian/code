            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(ms.ToArray());
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return result;
            }
