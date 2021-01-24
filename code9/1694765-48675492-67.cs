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
	
    private SslProtocols ExtractSslProtocol(requestStream)
    {
        BindingFlags bindingFlags = BindingFlags .Instance | BindingFlags .Public | 
                                    BindingFlags .NonPublic | BindingFlags.Static;
        var _objConnection = requestStream.GetType().GetField("m_Connection", bindingFlags).GetValue(requestStream);
        var _objTlsStream = _objConnection.GetType().GetProperty("NetworkStream", bindingFlags).GetValue(_objConnection);
        var _objSslState = _objTlsStream.GetType().GetField("m_Worker", bindingFlags).GetValue(_objTlsStream);
        return (SslProtocols)_objSslState.GetType().GetProperty("SslProtocol", bindingFlags).GetValue(_objSslState);
    }
