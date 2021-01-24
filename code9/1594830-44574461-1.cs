        var respObj = new object(); //resposneObjBody you have to define this object type added just for filler
        var settings = new XmlReaderSettings
        {
            IgnoreWhitespace = true
        };
        
        using (MemoryStream ms = new MemoryStream())
        {
                XmlSerializer xs = new XmlSerializer(respObj.GetType());
                xs.Serialize(ms, respObj);
                ms.Position = 0; 
                var reader = XmlReader.Create(ms, settings);
                var newMessage = Message.CreateMessage(msgCopy.Version, null, reader); // action is null, but you may want to put your reply action here
                newMessage.Headers.Clear(); //you may not need this either
                newMessage.Headers.CopyHeadersFrom(msgCopy.Headers); //you may not need this either
                newMessage.Properties.CopyProperties(msgCopy.Properties); //optional??
        }
