    private void RefreshClientInfo(Client client)
    {
        Global.Database.Entry(client).Reload();
        SelectedClient = client;
        SetValue(SelectedClientProperty, client);
    }
