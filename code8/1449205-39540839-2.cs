    using (var conn As new SqlConnection("connection string here"))
    using (var cmd As new SqlCommand("INSERT INTO ExchangeTypes(MarketSelectionId) VALUES (@MarketSelectionId)", conn)
    {
        cmd.Parameters.Add("@MarketSelectionId", SqlDbType.VarChar, 200).Value = umarketiduselectionid;
        conn.Open();
        cmd.ExecuteNonQuery();
    }
