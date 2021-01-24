    [OperationContract]
	[WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
	string NotifyAuditLineUpdated(AuditLineUpdatedModel notification);
    // you can host this somewhere else
	[OperationContract]
	[WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
	string MyInternalService(AuditLineUpdatedModel notification);
	public string NotifyAuditLineUpdated(AuditLineUpdatedModel notification)
	{
		var isCallToMyInternalServiceRequired = VerificationMethod(notification);
		if(isCallToMyInternalServiceRequired)
		{
			using(var internalClient = new MyInternalServiceClient())
			{
				return internalClient.MyInternalService(notification);
			}
		}
		
		// Your NotifyAuditLineUpdated method body
	}
    private bool VerificationMethod(AuditLineUpdatedModel notification)
    {
        // your validation method.
    }
