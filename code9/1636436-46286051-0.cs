    //get the message one at a time from uids. catching any rare errors with a message
    try
    {
        MailMessage message = client.GetMessage(uid);
        ProcessMessage(message);
    }
    catch(Exception e)
    {
        System.Threading.Thread.Sleep(1000);
        SendErrorEmail("An exception has been caught: " + e.ToString() + 
                        Environment.NewLine + "UID: " + uid.ToString());
    }
