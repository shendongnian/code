    //Repeater ItemTemplate RadioButton
    <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="true" 
                OnCheckedChanged="RadioButton1_CheckedChanged"/>
    
    
    //Code Behind
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
    //Uncheck all RadioButtons of the rptCustomer
    foreach (RepeaterItem item in rptCustomer.Items)
    {
        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        {
            (RadioButton)item.FindControl("RadioButton1").Checked = false;
        }
    }
    //After foreach loop, set current selected checkbox checked
    (sender as RadioButton).Checked = true;
    }
