        var respObj = new object(); //resposneObjBody
        var settings = new XmlReaderSettings
        {
            IgnoreWhitespace = true
        };
        
        using (MemoryStream ms = new MemoryStream())
        {
            XmlSerializer xs = new XmlSerializer(respObj.GetType());
            xs.Serialize(ms, respObj);
            var reader = XmlReader.Create(ms, settings);
            var newMessage = Message.CreateMessage(reader, int.MaxValue, msgCopy.Version);
            newMessage.Headers.Clear();
            newMessage.Headers.CopyHeadersFrom(msgCopy.Headers);
        }
