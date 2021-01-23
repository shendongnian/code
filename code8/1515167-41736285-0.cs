    protected void dropdown1_SelectedIndexChanged(object sender, EventArgs e)
    {
       DropDownList ddlProduct = (DropDownList)sender;
       DataGridItem row = (DataGridItem) ddlProduct.NamingContainer;
       Label lblPrice = (Label)row.FindControl("amount_lbl");
       
       // Get current label Text
        string price = lblPrice.Text;
       // Perform your operations here
      
       // Assign the price value back to the label
       lblPrice.Text =  price;
    }
 
