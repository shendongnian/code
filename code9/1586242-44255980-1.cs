    MessagingService.Current.Subscribe(MessageKeys.ConnectivityChanged, (c) =>
    {
         IsConnected = CrossConnectivity.Current.IsConnected;
         // Additional things you want to do such as
         // DataAccess da = new DataAccess();
         // da.SendUntransferredData();
    });
   
