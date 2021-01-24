    protected void States_DataBound(object sender, EventArgs e)
    {
        var chkBoxList = sender as CheckBoxList;
        foreach (ListItem listItem in chkBoxList.Items)
        {
            listItem.Selected = someItem;
        }
    }
