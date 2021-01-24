    BindingFlags bindingFlags = BindingFlags .Instance | BindingFlags .Public | 
                                BindingFlags .NonPublic | BindingFlags .Static;
    FieldInfo m_Connection = ResponseStream.GetType().GetField("m_Connection", bindingFlags);
    var _objNetwork = m_Connection.GetValue(ResponseStream);
    PropertyInfo _NetworkStream = _objNetwork.GetType().GetProperty("NetworkStream", bindingFlags);
    var _objTlsStream = _NetworkStream.GetValue(_objNetwork);
    FieldInfo m_Worker = _objTlsStream.GetType().GetField("m_Worker", bindingFlags);
    var objSslState = m_Worker.GetValue(_objTlsStream);
    PropertyInfo SslState = objSslState.GetType().GetProperty("SslProtocol", bindingFlags);
    string SslProtocol = SslState.GetValue(objSslState).ToString();
