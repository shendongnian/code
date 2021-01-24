    protected void insertBulkPricing()
    {
        try {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings("conio2").ConnectionString();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "INSERT INTO bulk_pricing (productID, rangeFrom, rangeTo, price, time, discount, status) VALUES(@productID, @rangeFrom, @rangeTo, @price, @time, @discount, @status)";
            cmd.Parameters.AddWithValue("@productID", productID.Text);
            cmd.Parameters.AddWithValue("@rangeFrom", bulkRangeFrom.Text);
            cmd.Parameters.AddWithValue("@rangeTo", bulkRangeTo.Text);
            cmd.Parameters.AddWithValue("@price", bulkPrice.Text);
            cmd.Parameters.AddWithValue("@time", bulkTime.Text);
            cmd.Parameters.AddWithValue("@discount", bulkDiscount);
            cmd.Parameters.AddWithValue("@status", "active");
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            this.bindBulkPricing();
        } catch (Exception ex) {
            Response.Write(ex);
        }
    }
