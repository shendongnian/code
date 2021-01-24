    public static SslProtocols? GetSslProtocol(Stream stream)
    {
        if (stream == null)
            return null;
        var flags = BindingFlags.NonPublic | BindingFlags.Instance;
        if (stream.GetType().FullName == "System.Net.ConnectStream")
        {
            var connection = stream.GetType().GetProperty("Connection", flags).GetValue(stream);
            var netStream = connection.GetType().GetProperty("NetworkStream", flags).GetValue(connection) as Stream;
            return GetSslProtocol(netStream);
        }
        if (stream.GetType().FullName == "System.Net.TlsStream")
        {
            var ssl = stream.GetType().GetField("m_Worker", flags).GetValue(stream);
            if (ssl.GetType().GetProperty("IsAuthenticated", flags).GetValue(ssl) as bool? != true)
            {
                // we're not authenticated yet. see: https://referencesource.microsoft.com/#System/net/System/Net/_TLSstream.cs,115
                var processAuthMethod = stream.GetType().GetMethod("ProcessAuthentication", flags);
                processAuthMethod.Invoke(stream, new object[] { null });
            }
            var protocol = ssl.GetType().GetProperty("SslProtocol", flags).GetValue(ssl) as SslProtocols?;
            return protocol;
        }
        if (stream.GetType().FullName == "System.Net.SslStream")
        {
            var ssl = stream as SslStream;
            return ssl.SslProtocol;
        }
        return null;
    }
