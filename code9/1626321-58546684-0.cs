    private bool IsRpcServerAlive()
    {
       // create a temporary channel since it will not be
       // reusable if an exception is thrown
       using (var tempChannel = connection.CreateModel())
       {
          try
          {
             // throws an exception if the Queue does not exist
             var declareResult = channel.QueueDeclarePassive("rpc_queue");
             // RPC server is the only consumer of the Queue
             return declareResult.ConsumerCount > 0;
          }
          catch (RabbitMQ.Client.Exceptions.OperationInterruptedException)
          {
             return false;
          }
       }
    }
