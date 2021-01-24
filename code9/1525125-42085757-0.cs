    public abstract class QueueConnection : IDisposable
    {
        internal IConnection _connection;
        internal IModel _model;
        internal IBasicProperties _properties;
        internal RabbitMQSettings _settings;
        internal protected object _modelLock = new Object();
        public QueueConnection(IOptions<RabbitMQSettings> queueConfig)
        {
            _settings = queueConfig.Value;
        }
        internal bool CreateModel(string queueName)
        {
            if (string.IsNullOrEmpty(queueName))
            {
                throw new ArgumentException("The queue name has to be specified before.");
            }
            lock (_modelLock)
            {
                if (!IsConnected) Connect();
                if (_model == null || _model.IsClosed)
                {
                    _model = _connection.CreateModel();
                    // When AutoClose is true, the last channel to close will also cause the connection to close. 
                    // If it is set to true before any channel is created, the connection will close then and there.
                    _connection.AutoClose = true;
                    // Configure the Quality of service for the model. Below is how what each setting means.
                    // BasicQos(0="Dont send me a new message untill I’ve finshed",  1= "Send me one message at a time", false ="Apply to this Model only")
                    _model.BasicQos(0, 50, false);
                    const bool durable = true, queueAutoDelete = false, exclusive = false;
                    _model.QueueDeclare(queueName, durable, exclusive, queueAutoDelete, null);
                    _properties = RabbitMQProperties.CreateDefaultProperties(_model);
                }
            }
            return true;
        }
        public void Connect()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = _settings.HostName,
                UserName = _settings.UserName,
                Password = _settings.Password,
            };
            if (_settings.Port.HasValue) connectionFactory.Port = _settings.Port.Value;
            if (_settings.Heartbeat.HasValue) connectionFactory.RequestedHeartbeat = _settings.Heartbeat.Value;
            if (!string.IsNullOrEmpty(_settings.VirtualHost)) connectionFactory.VirtualHost = _settings.VirtualHost;
            _connection = connectionFactory.CreateConnection();
        }
        public bool IsConnected
        {
            get { return _connection != null && _connection.IsOpen; }
        }
        public object GetConnection()
        {
            return _connection;
        }
        public void Disconnect()
        {
            if (_connection != null) _connection.Dispose();
        }
        void IDisposable.Dispose()
        {
            Disconnect();
        }
    }
