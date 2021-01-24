    //import librarys
    using IBM.WatsonDeveloperCloud.Conversation.v1;
    using IBM.WatsonDeveloperCloud.Conversation.v1.Model;
    using System;
    
    namespace IBM.WatsonDeveloperCloud.Conversation.Example
    {
        public class ConversationServiceExample
        {
            private ConversationService _conversation = new ConversationService();
            private string _workspaceID;
            private string _inputString = "Turn on the winshield wipers";
            
            //set username, password with Service Crentials
            public ConversationServiceExample(string username, string password, string workspaceID)
            {
                _conversation.SetCredential(username, password);
                _workspaceID = workspaceID; //workspace_id from your conversation created
    
                Message(); //send message
            }
