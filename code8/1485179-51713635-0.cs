    public async void Run(IBackgroundTaskInstance taskInstance)
    {
        var deferral = taskInstance.GetDeferral();
        try
        {
            var details = taskInstance.TriggerDetails as SocketActivityTriggerDetails;
            var socketInformation = details.SocketInformation;
            switch (details.Reason)
            {
                case SocketActivityTriggerReason.SocketActivity:
                    var socket = socketInformation.DatagramSocket;
                    socket.MessageReceived += Socket_MessageReceived;
    
                    // Wait for data to be read by MessageReceived handler (e.g., waiting on an event that is signaled by the handler).
                    // Write some data.
    
                    // Transfer socket ownership back to the broker.
                    await socket.CancelIOAsync();
                    socket.TransferOwnership(…);
                    break;
                default:
                    break;
            }
            deferral.Complete();
        }
        catch (Exception exception)
        {
            ShowToast(exception.Message);
            deferral.Complete();
        }
    }
    
    private void Socket_MessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
    {
        using (var reader = args.GetDataReader())
        {
            //TODO: read data here.
        }
    }
