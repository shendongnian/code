    private string GetResponse(string message)
    {
        const int RESPONSE_LENGTH = 4096;
        byte[] messageInBytes = Encoding.ASCII.GetBytes(message);
        
        bool leaveStreamOpen = true;
        using(var writer = new BinaryWriter(client.GetStream()))
        {
            writer.Write(messageInBytes);
        }
        using(var reader = New BinaryReader(client.GetStream()))
        {
            byte[] bytes = reader.Read(RESPONSE_LENGTH );
            return Encoding.ASCII.GetString(bytes);
        }
    }    
