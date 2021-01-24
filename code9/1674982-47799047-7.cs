    using(var connection = new SqlConnection(dbConnection))
    using(var command = new SqlCommand(query, dbConnection))
    using(var reader = new SqlDataReader())
         while(reader.Read())
         {
              Total.Add(GetValueOrNull<decimal>(reader, "TotalCost");
              Sqft.Add(GetValueOrNull<decimal>(reader, "Sqft1");
         }
