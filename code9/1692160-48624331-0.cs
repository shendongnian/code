    private CancellationToken _cancellationToken;
    private IConnection _connection;
    private IConnectionFactory _connectionfactory;
    private IMessageConsumer _consumer;
    private IDestination _destination;
    private MessageFormat _msgFormat;
    private IMessageProducer _producer;
    private ISession _session;
    private bool _reConnectOnConnectionBreak = false;
    private bool _connected = false;
    private void CreateWebsphereQueueConnection () {
        SetConnectionFactory ();
    
        while (!_connected || _reConnectOnConnectionBreak) {
            try {
                //Connection
                _connection = _connectionfactory.CreateConnection (null, null);
                _connection.ExceptionListener = new ExceptionListener (OnConnectionException);
    
                //Session
                _session = _connection.CreateSession (false, AcknowledgeMode.AutoAcknowledge);
    
                //Destination
                _destination = _session.CreateQueue ("queue://My.Queue.Name");
                _destination.SetIntProperty (XMSC.DELIVERY_MODE, 2);
                _destination.SetIntProperty (XMSC.WMQ_TARGET_CLIENT, 0);
    
                //Consumer
                _consumer = _session.CreateConsumer (_destination);
                _connected = true;
            } catch (Exception ex) {
                _connected = false;
            }
    
        }
    }
    
    private IConnectionFactory SetConnectionFactory () {
        XMSFactoryFactory factoryFactory = XMSFactoryFactory.GetInstance (XMSC.CT_WMQ);
        IConnectionFactory cf = factoryFactory.CreateConnectionFactory ();
    
        // Set the properties
        cf.SetStringProperty (XMSC.WMQ_CHANNEL, ConnectionSettings.Channel);
        cf.SetIntProperty (XMSC.WMQ_CONNECTION_MODE, XMSC.WMQ_CM_CLIENT);
        cf.SetIntProperty (XMSC.WMQ_FAIL_IF_QUIESCE, XMSC.WMQ_FIQ_YES);
        cf.SetStringProperty (XMSC.WMQ_QUEUE_MANAGER, ConnectionSettings.QueueManager);
        cf.SetStringProperty (XMSC.WMQ_CONNECTION_NAME_LIST, ConnectionSettings.ConnectionList);
        cf.SetIntProperty (XMSC.WMQ_CLIENT_RECONNECT_TIMEOUT, ConnectionSettings.ReconnectTimeout);
        cf.SetIntProperty (XMSC.WMQ_CLIENT_RECONNECT_OPTIONS, ConnectionSettings.ReconnectOptions);
    
        cf.SetStringProperty (XMSC.WMQ_PROVIDER_VERSION, XMSC.WMQ_PROVIDER_VERSION_DEFAULT);
        cf.SetBooleanProperty (XMSC.WMQ_SYNCPOINT_ALL_GETS, true);
        return cf;
    }
    
    public override void Subscribe<T> (Action<T> onMessageReceived) {
        try {
    
            _connection.ExceptionListener = delegate (Exception connectionException) {
                XMSException xmsError = (XMSException) connectionException;
                int reasonCode = ((IBM.WMQ.MQException) (xmsError).LinkedException).ReasonCode;
                if (reasonCode == MQC.MQRC_Q_MGR_QUIESCING || reasonCode == MQC.MQRC_CONNECTION_BROKEN) {
                    _reConnectOnConnectionBreak = true;
                    _connection.Close ();
    
                    CreateWebsphereQueueConnection ();
                    Subscribe (onMessageReceived);
                    _reConnectOnConnectionBreak = false;
                }
            }
    
            MessageListener messageListener = new MessageListener ((msg) => {
                onMessageReceived (message);
            });
            _consumer.MessageListener = messageListener;
    
            // Start the connection
            _connection.Start ();
        } catch (Exception ex) {
            //Log exception details
        }
    }
