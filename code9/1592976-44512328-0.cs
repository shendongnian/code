        await Initialize();
        if (!(await CrossConnectivity.Current.IsRemoteReachable(Client.MobileAppUri.Host, 443)))
        {
            Debug.WriteLine($"Cannot connect to {Client.MobileAppUri} right now - offline");
            return;
        }
        await tablaVehiculos.PullAsync("Ficha", tablaFicha.CreateQuery());
        await MobileService.SyncContext.PushAsync();
