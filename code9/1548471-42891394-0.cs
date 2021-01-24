    public bool CheckConnection()
    {
        if (pipeFactory == null)
        {
            pipeFactory = new DuplexChannelFactory<IService>(new InstanceContext(_instance), new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/ipc"));
        }
        try
        {
            switch (pipeFactory.State)
            {
                case CommunicationState.Faulted:
                    pipeFactory.Abort();
                    pipeFactory = new DuplexChannelFactory<IService>(new InstanceContext(_instance), new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/ipc"));
                    service = pipeFactory.CreateChannel();
                    service.Connect();
                    break;
                case CommunicationState.Closed:
                    service = pipeFactory.CreateChannel();
                    service.Connect();
                    break;
                case CommunicationState.Created:
                    service = pipeFactory.CreateChannel();
                    service.Connect();
                    break;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            throw;
        }
        return pipeFactory.State == CommunicationState.Opened;
    }
