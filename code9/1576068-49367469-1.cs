    using IBM.WatsonDeveloperCloud.Conversation.v1.Model;
    using IBM.WatsonDeveloperCloud.Conversation.v1;
    	
    static void Main(string[] args)
    {
    	// create a Language Translator Service instance
    	ConversationService _conversation = new ConversationService("<username>", "<password>", "<version>");
    
    	//  create message request
    	MessageRequest messageRequest = new MessageRequest()
    	{
    		Input = new InputData()
    		{
    			Text = "<input-string>"
    		}
    	};
    
    	//  send a message to the conversation instance
    	var result = _conversation.Message("<workspace-id>", messageRequest);
    }
