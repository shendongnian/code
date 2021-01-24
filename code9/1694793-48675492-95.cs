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
                                               SecurityProtocolType.Tls12;
	    ServicePointManager.ServerCertificateValidationCallback += TlsValidationCallback;
	
	    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(decodedUri);
	    if (requestPayload.Length > 0)
	    {
	        using (Stream requestStream = request.GetRequestStream())
	        {
	            //Here the request stream is already validated
	            SslProtocols SslProtocol = ExtractSslProtocol(requestStream);
	            requestStream.Write(requestPayload, 0, requestPayload.Length);
	        }
	    }
	    //(...)
	
    private SslProtocols ExtractSslProtocol(Stream stream)
    {
        if (stream is null) return SslProtocols.None;
        BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        Stream metaStream = stream;
        try
        {
            if (stream.GetType().BaseType == typeof(GZipStream))
                metaStream = stream as GZipStream;
            else if (stream.GetType().BaseType == typeof(DeflateStream))
                metaStream = stream as DeflateStream;
            var baseStream = metaStream?.GetType().GetProperty("BaseStream").GetValue(stream);
            var connection = baseStream.GetType().GetProperty("Connection", bindingFlags).GetValue(baseStream);
            var tlsStream = connection.GetType().GetProperty("NetworkStream", bindingFlags).GetValue(connection);
            var tlsState = tlsStream.GetType().GetField("m_Worker", bindingFlags).GetValue(tlsStream);
            return (SslProtocols)tlsState.GetType().GetProperty("SslProtocol", bindingFlags).GetValue(tlsState);
        }
        finally
        {
            metaStream.Dispose();
        }
    }
