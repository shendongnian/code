    [OperationContract]
	[WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
	string NotifyAuditLineUpdated(AuditLineUpdatedModel notification);
    // you can host this somewhere else
	[OperationContract]
	[WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
	string MyInternalService(AuditLineUpdatedModel1 notification);
	public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext)
	{
		object response;
		var isCallToMyInternalServiceRequired = VerificationMethod(request, out response);
		if(!isCallToMyInternalServiceRequired)
		{
			using(var client = new NotifyAuditLineUpdatedClient())
			{
				return client.NotifyAuditLineUpdated(response as AuditLineUpdatedModel);
			}
		}
		
		using(var client = new MyInternalServiceClient())
		{
			return client.MyInternalServiceClient(response as AuditLineUpdatedModel1);
		}
	}	
    private bool VerificationMethod(object notification, out object output)
    {
        // your validation method.
    }
