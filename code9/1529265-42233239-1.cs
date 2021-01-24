    MQMessage msg = new MQMessage();
    while (true)
    {
       get.Get(msg, gmo);
       Console.WriteLine(msg.ReadString(msg.MessageLength));
       msg.ClearMessage();
       msg.MessageId = MQC.MQMI_NONE;
       msg.CorrelationId = MQC.MQCI_NONE;
    }
