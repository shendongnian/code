    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
    request.Method = "POST";
    request.Headers.Add("Authorization", string.Format("Bearer {0}",AccessToken));
    request.ContentType = "application/json;charset=utf-8";
    request.ContentLength = body.Length;
    request.Accept = "application/json"
    
    if (!string.IsNullOrWhiteSpace(body))
                {
                    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                    byte[] bytes = encoding.GetBytes(body);
    
                    request.ContentLength = bytes.Length;
    
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        // Send the data.
                        requestStream.Write(bytes, 0, bytes.Length);
                    }
                }
    
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (callback != null)
                    {
                        var reader = new StreamReader(response.GetResponseStream());
                        callback(reader.ReadToEnd());
                    }
                }
