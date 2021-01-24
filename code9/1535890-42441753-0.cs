     private void RefreshClientInfo(Client client)
        {
            Global.Database.Entry(client).Reload();
            LastStatus = client.last_status;
            SetValue(SelectedClientProperty, client);
        }
