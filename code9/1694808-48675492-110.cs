    using System.Net;
    using System.Net.Security;
    using System.Reflection;
    using System.Security.Authentication;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
	    //(...)
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | 
                                               SecurityProtocolType.Tls | 
                                               SecurityProtocolType.Tls11 | 
                                               SecurityProtocolType.Tls12 | 
                                               SecurityProtocolType.Tls13;
	    ServicePointManager.ServerCertificateValidationCallback += TlsValidationCallback;
	
	    HttpWebRequest request = WebRequest.CreateHttp(decodedUri);
        using (Stream requestStream = request.GetRequestStream()) {
            //Here the request stream is already validated
            SslProtocols sslProtocol = ExtractSslProtocol(requestStream);
            if (sslProtocol < SslProtocols.Tls12)
            {
                // Refuse/close the connection
            }
        }
	    //(...)
	
    private SslProtocols ExtractSslProtocol(Stream stream)
    {
        if (stream is null) return SslProtocols.None;
        BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        Stream metaStream = stream;
        if (stream.GetType().BaseType == typeof(GZipStream)) {
            metaStream = stream as GZipStream;
        }
        else if (stream.GetType().BaseType == typeof(DeflateStream)) {
            metaStream = stream as DeflateStream;
        }
        var baseStream = metaStream?.GetType().GetProperty("BaseStream").GetValue(stream);
        var connection = baseStream.GetType().GetProperty("Connection", bindingFlags).GetValue(baseStream);
        var tlsStream = connection.GetType().GetProperty("NetworkStream", bindingFlags).GetValue(connection);
        var tlsState = tlsStream.GetType().GetField("m_Worker", bindingFlags).GetValue(tlsStream);
        return (SslProtocols)tlsState.GetType().GetProperty("SslProtocol", bindingFlags).GetValue(tlsState);
    }
