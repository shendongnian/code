    using (var conn As new SqlConnection("connection string here"))
    using (var cmd As new SqlCommand("Update ExchangeTypes SET LayOdds = @LayOdds, Size = @LaySize WHERE MarketId= @MarketId AND SelectionId = @SelectionID ", conn)
    {
        //Guessing at your column types/lengths here
        cmd.Parameters.Add("@LayOdds", SqlDbType.VarChar, 200).Value = layOdds;
        cmd.Parameters.Add("@LaySize", SqlDbType.Int).Value = laySize;
        cmd.Parameters.Add("@MarketId", SqlDbType.Int).Value = marketid;
        cmd.Parameters.Add("@SelectionId", SqlDbType.Int).Value = selectionid;
        conn.Open();
        cmd.ExecuteNonQuery();
    }
