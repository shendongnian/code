    SqlConnection sqlConn = new SqlConnection("[Your Connection String]");
    SqlCommand sqlcomm = new SqlCommand("[Your SP name]", sqlConn);
    sqlcomm.CommandType = CommandType.StoredProcedure;
    foreach (KeyValuePair<string, object> itm in myDictionary)
    {
        sqlcomm.Parameters.AddWithValue(itm.Key, itm.Value);
    }
    sqlcomm.CommandText = spName;
    
    sqlConn.Open();
    sqlcomm.ExecuteNonQuery();
        
