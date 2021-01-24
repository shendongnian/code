    protected void rgEffectivePermissions_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(((RadGrid)sender).SelectedItems.Count > 0)
        {
            rgSecurityGroup.DataSource = GetGridSource(int.Parse(((GridDataItem)((RadGrid)sender).SelectedItems[0])["SystemUserID"].Text));
            rgSecurityGroup.Rebind();
        }
    }
