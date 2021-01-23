    con.Open();
    SqlCommand cmd1 = new SqlCommand("ePMT_SP_BindSupplierDDLToTextBox", con);
    cmd1.Parameters.Add(new SqlParameter("@SupplierEmail",ddlSupplier.SelectedItem));
    SqlDataReader datareader = cmd.ExecuteReader(); 
    while(datareader.Read())
    {
    	txtSupplierEmail.Text = datareader["SupplierEmail"].ToString();
    }
