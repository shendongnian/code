    settings.ToolbarItemClick += (s, e) => 
    {
        var gridView = s as MVCxGridView;
        if(gridView == null)
            return;
        if(e.Item.Command == GridViewToolbarCommand.ExportToXlsx) {
            gridView.Columns["Text"].Visible = false;
        }
    };
