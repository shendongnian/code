            var messageBuffer = string.Empty;
            var request = WebRequest.Create("http://192.168.0.152:80/ISAPI/Event/notification/alertStream");
            request.Credentials = new NetworkCredential("admin", "P@55w0rd");
            request.BeginGetResponse(ar =>
            {
                var req = (WebRequest)ar.AsyncState;
                // TODO: Add exception handling: EndGetResponse could throw
                using (var response = req.EndGetResponse(ar))
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    // This loop goes as long as the api is streaming
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        
                        if (line == xmlEndStr)
                        {
                            messageBuffer += line;
                            GotMessage(messageBuffer);
                            messageBuffer = string.Empty;
                        }
                        else if (line.StartsWith("<"))
                        {
                            messageBuffer += line;
                        }
                    }
                }
            }, request);
        static void GotMessage(string msg)
        {
            var mySerializer = new XmlSerializer(typeof(EventNotificationAlert));
            var stringReader = new StringReader(msg);
            var eventAlert = (EventNotificationAlert)mySerializer.Deserialize(stringReader);
            Console.WriteLine($"DateTime: {eventAlert.dateTime} Channel: {eventAlert.channelID} Type: {eventAlert.eventType} Description: {eventAlert.eventDescription}");
        }
