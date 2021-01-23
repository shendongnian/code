    private void gridView1_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
    {
        var view = (GridView)sender;
        var info = (GridGroupRowInfo)e.Info;
        var caption = info.Column.Caption;
        if (info.Column.Caption == string.Empty)
        {
            caption = info.Column.ToString();
        }
        var groupInfo = info.RowKey as GroupRowInfo;
        info.GroupText = $"{caption} : {info.GroupValueText} ({groupInfo?.ChildControllerRowCount})";
    }
