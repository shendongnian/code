    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        HttpRequestMessageProperty prop;
        if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
        {
             prop = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
        }
        else
        {
             prop = new HttpRequestMessageProperty();
             request.Properties.Add(HttpRequestMessageProperty.Name, prop);
        }
        prop.Headers.Add("SessionId", this.sessionId);
        prop.Headers.Add("DeviceKey", this.deviceKey.ToString());
    }
