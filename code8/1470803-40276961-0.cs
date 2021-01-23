    try
    {
        using(SqlConnection connection = new SqlConnection(conString))
        using(SqlCommand cmd = new SqlCommand())
        {
            string strcom = "INSERT INTO trans_daily (retail_id, cust_name, quantity, " +
        "price, date, visibility, remarks_id) VALUES (@RetailID, @CustomerName, " +
        "@Quantity, @Price, @Date, @Visibility, @RemarksID)";
        
            cmd.CommandText = strcom;
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@RetailID", ddRetailType.SelectedValue);
            cmd.Parameters.AddWithValue("@CustomerName", tbCustomer.Text);
            cmd.Parameters.AddWithValue("@Quantity", float.Parse(tbQuantity.Text));
            cmd.Parameters.AddWithValue("@Price", float.Parse(tbPrice.Text));
            cmd.Parameters.AddWithValue("@Date", DateTime.Now);
            cmd.Parameters.AddWithValue("@Visibility", 1);
            cmd.Parameters.AddWithValue("@RemarksID", 1);
            int affectedRows = cmd.ExecuteNonQuery();
            Console.WriteLine("You have inserted {0} rows", affectedRows);
        }
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
