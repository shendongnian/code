     using (var clientTest = new ImapClient())
     {
        clientTest.Connect("xxxx@frontier.com");
        clientTest.AuthenticationMechanisms.Remove("XOAUTH");
        clientTest.Authenticate(eMail, pw);
        bIsConnected = clientTest.IsConnected;
 
         if (bIsConnected == true)
         {
            /// Insert Code here
         }
     }
