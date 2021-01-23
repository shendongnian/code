    public void LoadCustomerDetails()
    {
        lblMessage.Text = "";
        if (String.IsNullOrWhiteSpace(txtCID.Text))
        {
            lblMessage.Text = "Please enter a CustomerID before obtaining details.";
            return;
        }
        DataTable table = new DataTable();
        int customerID;
        using (var conn = new SqlConnection(Properties.Settings.Default.TestDbCon))
        using (var da = new SqlDataAdapter("GetCustomer", conn))
        using (var cmd = da.SelectCommand)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            if (!int.TryParse(txtCID.Text.Trim(), out customerID))
            {
                lblMessage.Text = "Please enter a valid integer CustomerID before obtaining details.";
                return;
            }
            cmd.Parameters.Add("@CustID", SqlDbType.Int).Value = customerID;
            da.Fill(table); // you don't need to open/close the connection with Fill
        }
        if (table.Rows.Count == 0)
        {
            lblMessage.Text = $"No customer with CustomerID={customerID} found.";
            return;
        }
        DataRow custumerRow = table.Rows.Cast<DataRow>().Single(); // to cause an exception on multiple customers with this ID
        txtFName.Text = custumerRow.Field<string>("FirstName");
        txtLName.Text = custumerRow.Field<string>("Surname");
        rdoGender.Text = custumerRow.Field<string>("Gender").ToString();
        txtAge.Text = custumerRow.Field<int>("Age").ToString();
        txtAdd1.Text = custumerRow.Field<string>("Address1").ToString();
        txtAdd2.Text = custumerRow.Field<string>("Address2").ToString();
        txtCity.Text = custumerRow.Field<string>("City").ToString();
        txtPhone.Text = custumerRow.Field<string>("Phone").ToString();
        txtMobile.Text = custumerRow.Field<string>("Mobile").ToString();
        txtEmail.Text = custumerRow.Field<string>("Email").ToString();
    }
