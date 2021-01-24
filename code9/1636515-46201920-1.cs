    public void SendData()
    {
        List<IMessageData> data;
        if (logic == 1)
        {
            data = new List<MessageData>();
        }
        else if (logic == 2)
        {
            data = new List<MultiMessageData>();
        }
        else
        {
            data = new List<SocialData>();
        }
        // some work here...
        foreach (var d in data)
        {
            //Only methods that will work are ones declared in the IMessageData interface
            d.SesDate(DateTime.Now);
            d.SetIsSent(true);
        }
        // if I do that then this Send method I will change it to be a Generic T maybe.
        _sendRepository.Send(data);
    }
