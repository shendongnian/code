    try
      {
        using (var client = new HttpClient())
            {
                response = await client.PostAsync(endpoint, new StreamContent(fileStream));
            }
     }
     catch (ProtocolViolationException protocolViolationException)
            {
                //supress error
            }
