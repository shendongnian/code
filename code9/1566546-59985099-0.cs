    using (var client = _clientFactory.GetClient())
    {
    	var credentials = Utils.EncodeTo64("user123:password");
    	client.ChannelFactory.CreateChannel();
    	using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
    	{
    		var httpRequestProperty = new HttpRequestMessageProperty();
    		httpRequestProperty.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
    		OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
    		//operation
    		client.Send(request);
    	}
    }
