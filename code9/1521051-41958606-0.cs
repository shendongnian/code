    private void DoNavigation()
    {
        var parameters = new NavigationParameters();
        var paramPayload = new Tuple<string, Maquina>("Maquina", _maquina);
        parameters.Add("Payload", paramPayload);
        _regionManager.RequestNavigate(IdRegion, Uri, parameters);
    }
