     public Client SelectedClient
    {
        get { return GetValue<Client>(SelectedClientProperty); }
        set { 
                 SetValue(SelectedClientProperty, value);
                 if(value == null)
                 {
                     return;
                 }
                 var qry = Global.DbContext.Logs.Where(c => c.client_id ==   value.client_id);
                qry.Load();
                LogEntries.Clear();
                foreach(var entry in qry)
                {
                    LogEntries.Add(entry);
                }
            }
    }
