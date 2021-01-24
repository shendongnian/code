       MessageListener messageListener = new MessageListener((m) =>         
        try
        {
            onMessageReceived();
        }
        catch (Exception)
        {
            throw;
        });`
