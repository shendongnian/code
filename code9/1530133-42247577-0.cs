     public ObservableCollection<Client> Clients
    {
        get { return GetValue<ObservableCollection<Client>>(ClientsProperty); }
        set { 
                 SetValue(ClientsProperty, value);
                 var qry = Global.DbContext.Logs.Where(c => c.client_id ==   SelectedClient.client_id);
                qry.Load();
                LogEntries.Clear();
                foreach(var entry in qry)
                {
                    LogEntries.Add(entry);
                }
            }
    }
