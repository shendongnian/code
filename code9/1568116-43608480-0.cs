    private void ApplyFilter()
    {
        string sConn = @"Data Source=;Initial Catalog=;
                    User ID=;Password=;";
        using (SqlConnection sc = new SqlConnection(sConn))
        {
            sc.Open();
            if (txtSupplier != null && !string.IsNullOrEmpty(txtSupplier.Text))
            {
                sql1 = "CompanyName like '" + txtSupplier.Text + "%'and ";
            }
            else
            {
                sql1 = "";
            }
                .
                .
                .
                if (txtPrice != null && !string.IsNullOrEmpty(txtPrice.Text))
            {
                sql17 = "Price like '" + txtPrice.Text + "%'and ";
            }
            else
            {
                sql17 = "";
            }
            if (cboSelectTop == null)
                return;
            if (cboSelectTop.Text == "ALL")
                    ...
                }
    }
