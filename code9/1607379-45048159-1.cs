            var main = new MultipartFormDataContent(Guid.NewGuid().ToString());
            HttpContent content = new StringContent("image.jpg");
            content.Headers.Clear();
            content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "fileName" };
            main.Add(content);
            content = new StreamContent(new MemoryStream(new byte[] { 1, 2, 3 }));//your file stream, or other base64 string
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
            content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "fileUpload", FileName="image.jpg" };
            main.Add(content);
            req.Content = main;
