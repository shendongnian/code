    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    {
    	HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
    	httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] =  
            "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(WCFWrapper.Username.Value + ":" + WCFWrapper.Password.Value));
    	request.Properties[HttpRequestMessageProperty.Name] = httpRequestProperty;
    
    	return null;
    }
