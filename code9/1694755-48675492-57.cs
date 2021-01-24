    using System.Reflection;
    BindingFlags bindingFlags = BindingFlags .Instance | BindingFlags .Public | 
                                BindingFlags .NonPublic | BindingFlags .Static;
    var _objConnection = requestStream.GetType().GetField("m_Connection", bindingFlags)
                                      .GetValue(requestStream);
    var _objTlsStream = _objConnection.GetType().GetProperty("NetworkStream", bindingFlags)
                                      .GetValue(_objConnection);
    var objSslState = _objTlsStream.GetType().GetField("m_Worker", bindingFlags)
                                   .GetValue(_objTlsStream);
    string SslProtocol = objSslState.GetType().GetProperty("SslProtocol", bindingFlags)
                                    .GetValue(objSslState).ToString();;
