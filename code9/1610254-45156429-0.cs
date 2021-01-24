    ddlETCsc1.Items.Clear();
    ddlETCsc2.Items.Clear();
    foreach (var PSiteContacts in ContactsAdapter.GetPSiteContacts(Cus_Id))
    {
        var item1 = new System.Web.UI.WebControls.ListItem();    
        item1.Text = PSiteContacts.name + " / " + PSiteContacts.phone;
        item1.Value = PSiteContacts.name + " / " + PSiteContacts.phone;
        item1.Attributes.Add("data-subtext", PSiteContacts.con_type);
        ddlETCsc1.Items.Add(item1);
        var item2 = new System.Web.UI.WebControls.ListItem();    
        item2.Text = PSiteContacts.name + " / " + PSiteContacts.phone;
        item2.Value = PSiteContacts.name + " / " + PSiteContacts.phone;
        item2.Attributes.Add("data-subtext", PSiteContacts.con_type);
        ddlETCsc2.Items.Add(item2);
     }
    ddlETCsc1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Nothing Selected", "0"));
    ddlETCsc2.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Nothing Selected", ""));
