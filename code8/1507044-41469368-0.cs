    string connectioStr = "Data Source=DESKTOP-MQKIBSK\\SQLEXPRESS;Initial Catalog=inventory2;Integrated Security=True";
    string querySQL = "Update Items Set Barcode=@Barcode,Productname=@Productname,Prices=@Prices,Quantity=@Quantity where Barcode = @condition";
    // add more columns as you needed in the set
    using (SqlConnection conSQL = new SqlConnection(connectioStr))
    {
        using (SqlCommand cmdSQL = new SqlCommand())
        {
            cmdSQL.Connection = conSQL;
            cmdSQL.CommandText = querySQL;
            cmdSQL.Parameters.Add("@Barcode", SqlDbType.VarChar).Value = txtcode.Text;
            cmdSQL.Parameters.Add("@Productname", SqlDbType.VarChar).Value = txtitemname.Text;
            cmdSQL.Parameters.Add("@Prices", SqlDbType.VarChar).Value = txtPrices.Text;
            cmdSQL.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = txtquantity.Text;
            cmdSQL.Parameters.Add("@condition", SqlDbType.VarChar).Value = txtcode.Text;
            // Add all parameters specified in the query
            // use appropriate datatypes as per the type of columns
        }
    }
