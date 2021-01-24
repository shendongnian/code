    public async Task updateMessageStatus(string strMsgID, string strMsgIDServer, int timeToNext)
    {
        await Task.Run(() =>
        {
            global g = new global();
    
            int intStatus = g.checkSMSStatus(strMsgIDServer);
            //checkSMSStatus REQUEST SERVER 2 for status of message
            if (intStatus != 2)
            {
                //Update Status in the Database
            }
            else
            if (timeToNext < 3600000)
                Task.Delay(timeToNext * 10).ContinueWith((t) => updateMessageStatus(strMsgID, strMsgIDServer, timeToNext * 10));
        });
    }
