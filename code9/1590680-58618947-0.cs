    [WebMethod]
    public bool AcceptPush() 
    {
        ABCObject ObjectName = null;
    
        string contentType = HttpContext.Current.Request.ContentType;
        
        if (false == contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase)) return false;
    
        using (System.IO.Stream stream = HttpContext.Current.Request.InputStream)
        using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
        {
            stream.Seek(0, System.IO.SeekOrigin.Begin);
    
            string bodyText = reader.ReadToEnd(); bodyText = bodyText == "" ? "{}" : bodyText;
    
            var json = Newtonsoft.Json.Linq.JObject.Parse(bodyText);
    
            ObjectName = Newtonsoft.Json.JsonConvert.DeserializeObject<ABCObject>(json.ToString());
        }
        
        return true;			    
    }
