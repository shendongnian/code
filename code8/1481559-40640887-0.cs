    private void StartConversationCallback(IAsyncResult asyncop)
    {
        // this is called once the dialing completes..
        if (asyncop.IsCompleted == true)
        {
            ConversationWindow newConversationWindow = _automation.EndStartConversation(asyncop);
            AVModality avModality = newConversationWindow.Conversation.Modalities[ModalityTypes.AudioVideo] as AVModality;
            avModality.ModalityStateChanged += ConversationModalityStateChangedCallback;
        }
    }
    
    private void ConversationModalityStateChangedCallback(object sender, ModalityStateChangedEventArgs e)
    {
        AVModality avModality = sender as AVModality;
        if (avModality != null)
        {
            switch (e.NewState)
            {
                case ModalityState.Disconnected:
                    avModality.ModalityStateChanged -= ConversationModalityStateChangedCallback;
                    break;
    
                case ModalityState.Connected:
                    avModality.ModalityStateChanged -= ConversationModalityStateChangedCallback;
                    foreach (char c in "SOS")
                    {
                        avModality.AudioChannel.BeginSendDtmf(c.ToString(), null, null);
                        System.Threading.Thread.Sleep(300);
                    }
                    break;
            }
        }
    }
