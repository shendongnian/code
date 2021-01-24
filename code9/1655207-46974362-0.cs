    public class RabbitMQConnection : IRabbitMQConnectionFactory {
        private readonly RabbitMQConnectionDetail connectionDetails;
        
        public RabbitMQConnection(IOptions<RabbitMQConnectionDetail> connectionDetails) {
            this.connectionDetails = connectionDetails.Value;
        }
        public IConnection CreateConnection() {
            var factory = new ConnectionFactory {
                HostName = connectionDetails.HostName,
                UserName = connectionDetails.UserName,
                Password = connectionDetails.Password
            };
            var connection = factory.CreateConnection();
            return connection;
        }
    }
