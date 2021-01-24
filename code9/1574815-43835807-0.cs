        conn.Open();
        SqlCommand cmd43 = new SqlCommand(Product1ProfitPercentQuery, conn);
        SqlDataReader rd43 = cmd43.ExecuteReader();
        if (rd43.HasRows) {
            while (rd43.Read())
            {
                string Product1= rd43.GetString(0);
                Products.Add(Product1);
            }
        }
        rd43.Close();
        conn.Close(); 
