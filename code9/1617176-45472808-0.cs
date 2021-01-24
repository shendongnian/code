    MQMessage msg = new MQMessage();
    MQGetMessageOptions gmo = new MQGetMessageOptions();
    gmo.Options |= MQC.MQGMO_WAIT | MQC.MQGMO_FAIL_IF_QUIESCING;
    gmo.WaitInterval = 60000;  // wait 60 seconds
    
    try
    {
        inQ.Get(msg, gmo);
        System.Console.Out.WriteLine("Message Data: " + msg.ReadString(msg.MessageLength));
    }
    catch (MQException mqex)
    {
        System.Console.Out.WriteLine("MQTest62B CC=" + mqex.CompletionCode + " : RC=" + mqex.ReasonCode);
        if (mqex.Reason == MQC.MQRC_NO_MSG_AVAILABLE)
        {
            // no meesage - life is good - loop again
        }
    }
