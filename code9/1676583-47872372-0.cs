    // give it a valid request message, endpoint and soapaction
    static string CallService(string xml, string endpoint, string soapaction)
    {
        string result = String.Empty;
        var binding = new BasicHttpBinding();
        // create a factory for a given binding and endpoint
        using (var client = new ChannelFactory<IRequestChannel>(binding, endpoint))
        {
            var anyChannel = client.CreateChannel(); // Implements IRequestChannel
            // create a soap message
            var req = Message.CreateMessage(
                MessageVersion.Soap11,
                soapaction,
                XDocument.Parse(xml).CreateReader());
            // invoke the service
            var response = anyChannel.Request(req);
            // assume we're OK
            if (!response.IsFault)
            {
                // get the body content of the reply
                var content = response.GetReaderAtBodyContents();
                // convert to string
                var xdoc = XDocument.Load(content.ReadSubtree());
                result = xdoc.ToString();
            }
            else
            {
                //throw or handle
                throw new Exception("panic");
            }
        }
        return result;
    }
