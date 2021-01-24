    string data = "user=" + username + "&password=" + password;
    string url = "http://xyz.in/getuser.php/";
    byte[] buffer = Encoding.ASCII.GetBytes(data);
    HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(url);
    
    
    WebReq.Method = "POST";
    WebReq.ContentType = "application/x-www-form-urlencoded";
    WebReq.ContentLength = buffer.Length;
    
    using (Stream PostData = WebReq.GetRequestStream())
    {
        PostData.Write(buffer, 0, buffer.Length);
       
        HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
        
        using (Stream stream = WebResp.GetResponseStream())
        {
            using (StreamReader strReader = new StreamReader(stream))
            {
                string result = strReader.ReadToEnd();                            
            }                        
        }
        WebResp.Close();
    }
