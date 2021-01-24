    using (Pop3Client client = new Pop3Client())
    {
        client.Connect("pop.gmail.com", 995, true);
        client.Authenticate("mymail@gmail.com", "pasword", AuthenticationMethod.UsernameAndPassword);
    
        // Get the number of messages in the inbox
        int messageCount = client.GetMessageCount();
    
        for (int i = messageCount; i > 0; i--)
        {
    string msg = ASCIIEncoding.ASCII.GetString(client.GetMessage(i).RawMessage);
    
            System.IO.File.WriteAllText(@"d:\\My File2.log", msg);
            var body = System.IO.File.ReadLines(@"d:\\My File2.log");
            if (body.Contains("cusotmer ID: X"))
            {
                getemailadress();
                sendemail();
            }
        }
    }
