    TcpClient client = new TcpClient(decodedUri.DnsSafeHost, 443);
    SslStream sslStream = new SslStream(client.GetStream());
    // use this overload to ensure SslStream has the same scope of enabled protocol as HttpWebRequest
    sslStream.AuthenticateAsClient(decodedUri.Host, null,
        (SslProtocols)ServicePointManager.SecurityProtocol, true);
    // Check sslStream.SslProtocol here
    client.Close();
    sslStream.Close();
