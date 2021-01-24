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
        BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
        Stream CompressedStream = null;
        if (stream.GetType().BaseType == typeof(GZipStream))
            CompressedStream = (GZipStream)stream;
        else if (stream.GetType().BaseType == typeof(DeflateStream))
            CompressedStream = (DeflateStream)stream;
        var objbaseStream = CompressedStream?.GetType().GetProperty("BaseStream").GetValue(stream);
        if (objbaseStream == null) objbaseStream = stream;
        var objConnection = objbaseStream.GetType().GetField("m_Connection", bindingFlags).GetValue(objbaseStream);
        var objTlsStream = objConnection.GetType().GetProperty("NetworkStream", bindingFlags).GetValue(objConnection);
        var objSslState = objTlsStream.GetType().GetField("m_Worker", bindingFlags).GetValue(objTlsStream);
        return (SslProtocols)objSslState.GetType().GetProperty("SslProtocol", bindingFlags).GetValue(objSslState);
    }
