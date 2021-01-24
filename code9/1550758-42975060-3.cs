    conn.InfoMessage +=  TrackInfo;
    using (var cmd = new SqlCommand(@"SET STATISTICS TIME ON", conn)) {
    	cmd.ExecuteNonQuery();
    }
    using (var cmd = new SqlCommand(yourQuery, conn)) {
    	var RD = cmd.ExecuteReader();
    	while (RD.Read()) {
    		// read the columns
    	}
    }
