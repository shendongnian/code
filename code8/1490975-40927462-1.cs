    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        decimal amount = 0;
    
        if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
        {
            //get amount from somewhere
            //amount = 
        }
    
        txtAmount.Text = string.Format("{0:C}", amount);
    }
