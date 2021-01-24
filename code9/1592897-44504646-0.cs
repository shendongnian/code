    for (int i = 0; i<App.sysIni.monitorProperties.Count; ++i)
    {
        KeyValuePair<string, string> key = App.sysIni.monitorProperties[i];
        GridViewColumn column = new GridViewColumn();
        column.Header = key.Value;
        column.Width = 70;
        column.DisplayMemberBinding = new Binding("[" + i + "]");
        GridViewControlMonitor.Columns.Add(column);
    }
