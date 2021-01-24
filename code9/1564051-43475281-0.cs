     using (var stream = new MemoryStream())
            {
                context.Request.InputStream.Seek(0, SeekOrigin.Begin);
                context.Request.InputStream.CopyTo(stream);
                string requestBody = Encoding.UTF8.GetString(stream.ToArray());
                if(requestBody!=string.Empty)
                {
                    JObject inputReqObj = JObject.Parse(requestBody);
                    UserID = (string)inputReqObj["eUserID"];
                }
            }         
