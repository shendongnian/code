    public void SendData()
    {
        OneOf<List<MessageData>, List<MultiMessageData>, List<SocialData>> data = null;
    
        if(logic == 1){
            data = new List<MessageData>();
        } else if(logic == 2){
            data = new List<MultiMessageData>();
        }else {
            data = new List<SocialData>();
        }
    
        // some work here...
    
         
        _sendRepository.Send(data);
    }
