            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = username;
            factory.Password = password;
            factory.VirtualHost = virtualhost;
            factory.HostName = hostname;
            factory.Port = port;
            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();
