    connectionFactory.SetIntProperty(XMSC.WMQ_CLIENT_RECONNECT_OPTIONS, XMSC.WMQ_CLIENT_RECONNECT);                           
    connectionFactory.SetIntProperty(XMSC.WMQ_CLIENT_RECONNECT_TIMEOUT, 3600);                          
    connectionFactory.SetIntProperty(XMSC.WMQ_CONNECTION_MODE, XMSC.WMQ_CM_CLIENT_UNMANAGED);
    var queueConnection = connectionFactory.CreateConnection();
    queueConnection.ExceptionListener = OnException;
