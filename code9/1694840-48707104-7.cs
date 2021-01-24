    public static SslProtocols? GetSslProtocol(Stream stream)
    {
        if (stream == null)
            return null;
        if (typeof(SslStream).IsAssignableFrom(stream.GetType()))
        {
            var ssl = stream as SslStream;
            return ssl.SslProtocol;
        }
        var flags = BindingFlags.NonPublic | BindingFlags.Instance;
        if (stream.GetType().FullName == "System.Net.ConnectStream")
        {
            var connection = stream.GetType().GetProperty("Connection", flags).GetValue(stream);
            var netStream = connection.GetType().GetProperty("NetworkStream", flags).GetValue(connection) as Stream;
            return GetSslProtocol(netStream);
        }
        if (stream.GetType().FullName == "System.Net.TlsStream")
        {
            // type SslState
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
        return null;
    }
