    private const string MC_GOOGLE_APP_NAME = "from-google-00110";
    private const string MC_GOOGLE_SERVICE_ACCOUNT = "appname@from-google-00110.iam.gserviceaccount.com";
    private const string MC_PRIVATE_KEY = "-----BEGIN PRIVATE KEY-----\xxxx blah blah blah xxx\n-----END PRIVATE KEY-----\n";
    private const string MS_GMAIL_QUERY = "label: inbox, label: unread";
    
    //**** CRITICAL! THIS MUST EXACTLY MATCH THE SCOPES THAT YOUR App IS AUTHORZIED FOR ***
    private const string MS_SCOPES ="https://www.googleapis.com/auth/gmail.modify"; 
    private string msEmailAccount = "mike@blue-mosaic.com"; //the email account you are reading, not mine please
    
    //get credential for service account
    ServiceAccountCredential credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(MC_GOOGLE_SERVICE_ACCOUNT)
                    {
                        Scopes = MS_SCOPES,
                        User = msEmailAccount 
                    }.FromPrivateKey(MC_PRIVATE_KEY));
    
    //create a new gmail service
    GmailService oSVC =  GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = MC_GOOGLE_APP_NAME,
                });
    
    List<Google.Apis.Gmail.v1.Data.Message> aoMessageList = new List<Google.Apis.Gmail.v1.Data.Message>();
    UsersResource.MessagesResource.ListRequest request = oSVC.Users.Messages.List(msEmailAccount);
    request.Q = MS_GMAIL_QUERY;
    
    //keep making requests until all messages are read. 
    do
    {
    	ListMessagesResponse response = request.Execute();
    	if (response.Messages != null)
    	{
    	    aoMessageList.AddRange(response.Messages);
    	    request.PageToken = response.NextPageToken;
    	}
    
    } while (!String.IsNullOrEmpty(request.PageToken));
    
    //now read the body of each of the new messages
    foreach (Message oMsg in aoMessageList)
    {
    	string sMsgID = oMsg.Id;
    
    	sState = "Reading Message '" + sMsgID + "'";
    
    	// and this one gets a bit nuts. processing GMAIL messages took me a fair amount
    	// of reading, parsing and decoding, so it required a whole class!!
    	SaneMessage oThisMsg = new SaneMessage(oSVC, "me", sMsgID);
    
    	//and do something with the message
    }
