            byte[] textAsBytes = Encoding.Unicode.GetBytes(concatenatedStyles);
            using(MemoryStream stream = new MemoryStream(textAsBytes)) {
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(stream);
                httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {
                    FileName = "main-theme.scss"
                };
                httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/css");
                return ResponseMessage(httpResponseMessage);
            }
You might need to remove the using around the MemoryStream too, I'm not 100% sure as I can't compile your code on my system.
