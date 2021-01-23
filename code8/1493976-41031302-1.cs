    using (var cn = new MySqlDbConnection("your connection string here"))
    using (var cmd = new MySqlDbCommand("DELETE * from products WHERE ProductType= @productType;")) // Note that I removed the single quotes (')
    {
        //Use the actual column type and length here.
        // Ignore examples elsewhere online that use AddWithValue(). This is better!
        cmd.Parameters.Add("@productType", MySqlDbType.VarString, 25).Value = txtDeleteProduct.Text;
        cn.Open();
        cmd.ExecuteNonQuery();
    }
