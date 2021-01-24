    public static HttpWebResponse GetHttpResponse(this HttpWebRequest request)
    {
        try
        {
            return (HttpWebResponse) request.GetResponse();
        }
        catch (WebException ex)
        {
            if(ex.Response == null || ex.Status != WebExceptionStatus.ProtocolError)
                throw; 
    
            return (HttpWebResponse)ex.Response;
        }
    }
