    private List<MessageName> createMsgObject(Dictionary<string, string> infoHash, Dictionary<string, Int16> msgDescritionAndID)
    {
        MessageName msgName = null;
        List<MessageName> msgNameList = new List<MessageName>();
        var msgObjOuter = new MessageName();
        // there is no need to perform an o(1) lookup of infoHash for 40 variables. 
        // You already have a list of keys it contains so just enumerate them.
        foreach (KeyValuePair<string, string> info in infoHash)
        {
            var msg = new MessageName() { MessageID = msgDescritionAndID[info.Key] };
            switch (info.Key)
            {
                // switch all of your int16 versions first:
                case "redis_version":
                case "hash_int_message_2":
                case "hash_int_message_3":
                    msg.DiagnosticCnt = Convert.ToInt32(infoHash[info.Value]);
                    break;
                // switch on all message types getting int16 from info.Key
                case "msg_int_message_1":
                case "msg_int_message_2":
                    msg.DiagnosticCnt = Convert.ToInt32(msgDescritionAndID[info.Key]);
                    break;
                // everything left over is reading value from our current info.
                //  default:
                    msg.DiagnosticStr = info.Value;
                    break;
            }
            msgNameList.Add(msgName);
        }
        return msgNameList;
    }
