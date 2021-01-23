    using Microsoft.Lync.Model;
    using Microsoft.Lync.Model.Conversation;
    
    private static void SendMessage()
    {
        try
        {
            string[] arrRecepients = { "sip:receiver1@domain.com", "sip:receiver2@domain.com" }; //add your recepients here
            LyncClient lyncClient = LyncClient.GetClient();
            Conversation conversation = lyncClient.ConversationManager.AddConversation();
            foreach (string recepient in arrRecepients)
            {
                conversation.AddParticipant(lyncClient.ContactManager.GetContactByUri(recepient));
            }
            InstantMessageModality imModality = conversation.Modalities[ModalityTypes.InstantMessage] as InstantMessageModality;
            string message = GetNotification(); //use your existing notification logic here
            imModality.BeginSendMessage(message, null, null);
        }
        catch (Exception ex)
        {
        }
    }
