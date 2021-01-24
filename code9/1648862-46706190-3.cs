    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        String query = "INSERT INTO Products (Barcodes, Name, EDate, Quantity, Price) VALUES (@Barcodes, @Name, @EDate, @Quantity,@Price)";
    
        using(SqlCommand command = new SqlCommand(query, connection))
        {
            
    		SqlCommand command = new SqlCommand(query, db.Connection);
    		command.Parameters.AddWithValue("@Barcodes", this.tbxBar.Text )
    		command.Parameters.AddWithValue("@Name", this.tbxName.Text )
    		command.Parameters.AddWithValue("@EDate",this.dateDate.Value.Date)
    		command.Parameters.AddWithValue("@Quantity",this.tbxQua.Text)
    		command.Parameters.AddWithValue("@Price",this.tbxPrice.Text)
    
            int result = command.ExecuteNonQuery();
    
            // Check Error
            if(result < 0)
                // data insert error
        }
    }
