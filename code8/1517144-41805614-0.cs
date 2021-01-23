        try
        {
            await client.ConnectAsync(ip, port);
        }
        catch (Exception ex)
        {
            throw ex;
        }
 
        //...
            await client.WriteStream.WriteAsync(dati, 0, 8);
            await listener.StartListeningAsync(5555);         
