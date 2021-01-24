    List<int> productsIds = new List<int>() { 23, 46, 76, 88 };
    
    string idInParameter = String.Join(",", productsIds);
    
    // Create id as comma separated string
    string query = @"SELECT * FROM products WHERE id IN (@productId);";
    
    MySqlCommand cmd = new MySqlCommand(query, dbConn);
    cmd.Parameters.AddWithValue("productId", idInParameter);
    
    MySqlDataReader row = cmd.ExecuteReader();
    while (row.Read())
    {
        // Process result
        // ...
    }
