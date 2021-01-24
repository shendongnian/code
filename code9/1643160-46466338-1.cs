    MySql.Data.MySqlClient.MySqlCommand Command = new MySql.Data.MySqlClient.MySqlCommand(insertQuery, conn);
    
    Command.Parameters.AddWithValue("@produktname", productInfo.Product);
    Command.Parameters.AddWithValue("@unterprodukt", productInfo.Underproduct);
    Command.Parameters.AddWithValue("@version", productInfo.Version);
    
    Command.ExecuteNonQuery();
