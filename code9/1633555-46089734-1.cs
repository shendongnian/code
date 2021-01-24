    using (var cmd = new SqlCommand(@"INSERT INTO Products (Barcodes, Name, EDate, Quantity, Price) VALUES (@Barcodes, @Name, @EDate, @Quantity, @Price)", con))
    {
        cmd.Parameters.Add("@Barcodes", SqlDbType.Int).Value = barcodes;
        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
        cmd.Parameters.Add("@EDate", SqlDbType.DateTime).Value = date;
        cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
        cmd.Parameters.Add("@Price", SqlDbType.Int).Value = price;
        cmd.ExecuteNonQuery();
    }
