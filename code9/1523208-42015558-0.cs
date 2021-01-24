    public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
    {
       ...
       var s = GetJsonFromMessage(request);
       ...
    }
    private static string GetJsonFromMessage(ref Message request)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (XmlDictionaryWriter writer = JsonReaderWriterFactory.CreateJsonWriter(ms))
            {
                request.WriteMessage(writer);
                writer.Flush();
                string json = Encoding.UTF8.GetString(ms.ToArray()); //extract the JSON at this point
                //now let's make our copy of the message to support the WCF pattern of rebuilding messages after consuming the inner stream (see: https://msdn.microsoft.com/en-us/library/system.servicemodel.dispatcher.idispatchmessageinspector.afterreceiverequest(v=vs.110).aspx and https://blogs.msdn.microsoft.com/carlosfigueira/2011/05/02/wcf-extensibility-message-formatters/)
                ms.Position = 0; //Rewind. We're about to make a copy and restore the message we just consumed.
                XmlDictionaryReader reader = JsonReaderWriterFactory.CreateJsonReader(ms, XmlDictionaryReaderQuotas.Max); //since we used a JsonWriter, we read the data back, we need to use the correlary JsonReader.
                
                Message restoredRequestCopy = Message.CreateMessage(reader, int.MaxValue, request.Version); //now after a lot of work, create the actual copy
                restoredRequestCopy.Properties.CopyProperties(request.Properties); //copy over the properties
                request = restoredRequestCopy;
                return json;
            }
        }
    }
