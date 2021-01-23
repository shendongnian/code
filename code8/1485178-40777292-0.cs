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
