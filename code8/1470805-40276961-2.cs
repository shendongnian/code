    try
    {
        using(SqlConnection connection = new SqlConnection(conString))
        using(SqlCommand cmd = new SqlCommand())
        {
            string strcom = "INSERT INTO trans_daily ([retail_id], [cust_name], [quantity], " +
        "[price], [date], [visibility], [remarks_id]) VALUES (@RetailID, @CustomerName, " +
        "@Quantity, @Price, @Date, @Visibility, @RemarksID)";
        
            cmd.CommandText = strcom;
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue("@RetailID", SqlDbType.Int);
            cmd.Parameter["@RetailID"].Value = ddRetailType.SelectedValue;
            cmd.Parameters.AddWithValue("@CustomerName", SqlDbType.VarChar);
            cmd.Parameter["@CustomerName"].Value = tbCustomer.Text;
            cmd.Parameters.AddWithValue("@Quantity", SqlDbType.Float);
            cmd.Parameter["@Quantity"].Value = float.Parse(tbQuantity.Text);
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Float);
            cmd.Paramter["@Price"].Value = float.Parse(tbPrice.Text);
            cmd.Parameters.AddWithValue("@Date", SqlDbType.DateTime);
            cmd.Parameter["@Date"].Value = DateTime.Now;
            cmd.Parameters.AddWithValue("@Visibility", SqlDbType.Int);
            cmd.Parameter["@Visibility"].Value = 1;
            cmd.Parameters.AddWithValue("@RemarksID", SqlDbType.Int);
            cmd.Parameter["@RemarksID"].Value = 1;
            int affectedRows = cmd.ExecuteNonQuery();
            Console.WriteLine("You have inserted {0} rows", affectedRows);
        }
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
