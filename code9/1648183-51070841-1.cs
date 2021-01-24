    private void Setter_ToolTipOpening(object sender, ToolTipEventArgs e)
    {
        var dgc = (DataGridCell)sender;
        var row = (DataRowView)dgc.DataContext;
        string partcell = row["PartNumber"].ToString();
        PartHelper partProv = new PartHelper();
        (dgc.ToolTip as DataGrid).ItemsSource = partProv.PartByLocation(partcell, site);
    }
