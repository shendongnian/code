    using (OdbcConnection con = new OdbcConnection(Properties.Settings.Default.ConnectionString))
    {
    	var query ="INSERT INTO Kassatickets (id, datum, korting, totaal) VALUES (?, ?, ?, ?)";     
    	
    	OdbcCommand cmd = new OdbcCommand(query, con);
    	
    	cmd.Parameters.Add("id", OdbcType.UniqueIdentifier).Value = 3;
    	cmd.Parameters.Add("datum", OdbcType.VarChar).Value = '2018-02-15 07:06:00';
    	cmd.Parameters.Add("korting", OdbcType.VarChar).Value = kt.KortingId;
    	cmd.Parameters.Add("totaal", OdbcType.VarChar).Value = kt.Totaal;
    	con.Open();
    	if (cmd.ExecuteNonQuery() == 0)
    	{
    		throw new Exception("Er zijn geen wijzigingen uitgevoerd!!");
    	}
    }
