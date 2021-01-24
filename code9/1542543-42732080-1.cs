     HttpWebRequest request = (HttpWebRequest)WebRequest.Create(WebServiceOfServer);
     request.Method = "POST";
     //request.ContentType = "application/x-www-form-urlencoded";
     request.KeepAlive = true;
     request.Credentials = System.Net.CredentialCache.DefaultCredentials;
     var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
     request.ContentType = "multipart/form-data; boundary=" + boundary;
    
     byte[] fileData = null;
     using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }
                request.ContentLength = fileData.Length;
    
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileData, 0, fileData.Length);
    
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
    
                var result = reader.ReadToEnd();
                stream.Dispose();
                reader.Dispose();
