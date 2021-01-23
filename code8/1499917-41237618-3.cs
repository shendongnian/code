	public String GetAllDocuments(string url,int pager =0)
	{
		if (SessionInfo.IsAdmin)
		{
			return documentsData(_reportHandlerFactory, SessionInfo.ClientID, page);
		}
		else
		{
			return "Sorry!! You are not authorized to perform this action";
		}
	}
	private static String documentsData(
		IReportHandlerFactory reportHandlerFactory, 
		Guid clientID,
		int pager)
	{
		IReportHandler dal = reportHandlerFactory.Create();
		
		var documents = dal.FetchDocumentsList(clientID, pager);
		string documentsDataJSON = JsonConvert.SerializeObject(documents);
		return documentsDataJSON;
	}
