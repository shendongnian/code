    public class Statistics
    {
        private readonly IConnectionFactory connectionFactory;
        private readonly IConnection connection;
        private readonly ISession session;
    
        public Statistics( string brokerUri)
        {
            this.connectionFactory = new ConnectionFactory(brokerUri);
            this.connection = connectionFactory.CreateConnection();
            this.connection.Start();
            this.session = connection.CreateSession();
        }
    
        public void GetStats()
        {
            // Crear consumidor
    
    
            try
            {
                // Creo una cola y consumidor
                IDestination queueReplyTo = session.CreateTemporaryQueue();
                IMessageConsumer consumer = session.CreateConsumer(queueReplyTo);
    
                // Crear cola monitorizada
                string listeningQueue = "TEST1";
                ActiveMQQueue testQueue  =  session.GetQueue(listeningQueue);
    
    
                // Crear cola  y productor
                ActiveMQQueue query =  session.GetQueue("ActiveMQ.Statistics.Destination.TEST1");
                IMessageProducer producer = session.CreateProducer(null);
    
                // Mandar mensaje vacío y replicar
                IMessage msg = session.CreateMessage();
                producer.Send(testQueue, msg);
                msg.NMSReplyTo = queueReplyTo;
                producer.Send(query, msg);
    
                // Recibir
                IMapMessage reply = (IMapMessage)consumer.Receive();
    
    
                if (reply != null)
                {
                    IPrimitiveMap statsMap = reply.Body;
    
                    foreach (string statKey in statsMap.Keys)
                    {
                        Console.WriteLine("{0} = {1}", statKey, statsMap[statKey]);
                    }
                }
            }
            catch (Exception e)
            {
                var t = e.Message + " " + e.StackTrace;
            }
        }
    
    
    }
