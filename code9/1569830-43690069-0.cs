    object IDispatchMessageInspector.AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
    {
    	if (validateRequest)
    	{
    		if (!request.IsEmpty && !request.IsFault)
    		{
    			request = ValidateRequestMessageBody(request);
    			channel.Close();
    			channel.Dispose();
    		}
    	}
    	return null;
    }
    private Message ValidateRequestMessageBody(System.ServiceModel.Channels.Message message)
    {
    	//do stuff
    	var reader = XmlReader.Create(memStream, settings);                        
    	var newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
    	newMessage.Headers.Clear();
    	newMessage.Headers.CopyHeadersFrom(message.Headers);
    	return newMessage;
    }
