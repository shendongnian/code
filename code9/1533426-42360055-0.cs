    List<string> productsIds = new List<string>() { "23", "46", "76", "88" };
            string query = @"
				SELECT *
				FROM products
				WHERE id IN ({0});";
            // Execute query
            using (MySqlCommand cmd = new MySqlCommand(query, dbConn))
            {
                int index = 0;
                string sqlWhere = string.Empty;
                foreach (string id in productsIds)
                {
                    string parameterName = "@productId" + index++;
                    sqlWhere += string.IsNullOrWhiteSpace(sqlWhere) ? parameterName : ", " + parameterName;
                    cmd.Parameters.AddWithValue(parameterName, id);
                }
                query = string.Format(query, sqlWhere);
                cmd.CommandText = query;
                using (MySqlDataReader row = cmd.ExecuteReader())
                {
                    while (row.Read())
                    {
                        // Process result
                        // ...
                    }
                }
            }
