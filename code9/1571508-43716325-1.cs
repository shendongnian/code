    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        int itemsInCart = 3;
        //find the dropdownlist using findcontrol
        DropDownList drp = e.Item.FindControl("ddlqty") as DropDownList;
        //set the correct cart value
        drp.SelectedValue = itemsInCart.ToString();
    }
    protected void ddlqty_SelectedIndexChanged(object sender, EventArgs e)
    {
        //cast the sender back to a dropdownlist
        DropDownList drp = sender as DropDownList;
        //get the item as a repeater item
        RepeaterItem item = drp.NamingContainer as RepeaterItem;
        //find the label with the product ID in the Repeater
        Label lbl = Repeater1.Items[item.ItemIndex].FindControl("Label1") as Label;
        //get the product id from the attri
        int productID = Convert.ToInt32(lbl.Text);
        //convert the selectedvalue back to an int
        int itemsInCart = Convert.ToInt32(drp.SelectedValue);
        //you now have the product id and the new cart amount
    }
