    socketModel sm = new socketModel();
    sm.CHANNEL = "channel_" + cHAT_MESSAGES.SENDER_ID + cHAT_MESSAGES.RECEIVER_ID;
    sm.DATA = chatMessageModelObj;
    
    string serializedData = Newtonsoft.Json.JsonConvert.SerializeObject(sm);
    
    socketModel smSecond = new socketModel();
    smSecond.CHANNEL = "messagecount_" + cHAT_MESSAGES.RECEIVER_ID;
    
    if (updateCount == null)
    {
    	smSecond.DATA = 0;
    
    }
    else
    {
    	smSecond.DATA = updateCount.Count();
    }
    
    string serializedDataSecond = Newtonsoft.Json.JsonConvert.SerializeObject(smSecond);
    
    var socket = IO.Socket(ConfigurationManager.AppSettings["socketlink"].ToString());
    socket.Once(Socket.EVENT_CONNECT, () =>
    {
    	socket.Emit("apimessage", serializedData);
    	socket.Emit("apimessage", serializedDataSecond);
    });
    
    socket.Once("apimessage", () =>
    {
    	socket.Disconnect();
    });
