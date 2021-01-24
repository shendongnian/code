     string productIdsCommaSeparated = string.Join(",", productsIds.Select(n => n.ToString()).ToArray())
       string query = @"
            SELECT *
            FROM products
            WHERE id IN (@productId);";
    
        // Execute query
        MySqlCommand cmd = new MySqlCommand(query, dbConn);
        cmd.Parameters.AddWithValue("productId", productIdsCommaSeparated );
    
        MySqlDataReader row = cmd.ExecuteReader();
        while (row.Read())
        {
            // Process result
            // ...
        }
