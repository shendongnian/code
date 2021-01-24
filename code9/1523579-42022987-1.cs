    [WebMethod]
    public string POSTXml(string username, string password)
    {
        WebRequest req = null;
        WebResponse rsp = null;
        try
        {
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
                        return strReader.ReadToEnd();                            
                    }                        
                }
                WebResp.Close();
           }
        
        }
        catch (Exception e)
        {
            throw new Exception("There was a problem sending the message");
        }
        return String.Empty;
    }
