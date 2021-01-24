    private void DoNavigation()
    {
        var parameters = new NavigationParameters();
        var paramPayload = new NavigationPayload("Maquina", _maquina);
        parameters.Add("Payload", paramPayload);
        _regionManager.RequestNavigate(IdRegion, Uri, parameters);
    }
