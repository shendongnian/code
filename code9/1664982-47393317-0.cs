     protected void GVInvoiceDet_RowUpdating(object sender, GridViewRowEventArgs e)
     {
        string itemCode= (TextBox)GVInvoiceDet.Rows[e.RowIndex].FindControl("txtItemCode")).Text;
        string quantity = (TextBox)GVInvoiceDet.Rows[e.RowIndex].FindControl("txtItemQty")).Text;
        string unitRate = ((TextBox)GVInvoiceDet.Rows[e.RowIndex].FindControl("txtItemUnitRate")).Text;
        string unitValue = ((TextBox)GVInvoiceDet.Rows[e.RowIndex].FindControl("txtItemUnitValue")).Text;    
        string unit = Session["unit"].ToString();
        string proj = Session["project"].ToString();
        GVInvoiceDet.EditIndex = -1;
        // call bind grid method here
     }
