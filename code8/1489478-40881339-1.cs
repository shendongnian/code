    public void ProcessRequest(HttpContext context)
    {
        try
        {
            OracleDataReader rdr = null;
            OracleConnection dbConn;
            dbConn = Conn.getConn();
            string empcd = context.Request.QueryString["empcd"].ToString();
            OracleCommand cmd = new OracleCommand("select photo img from olphrm.emp_personal where emp_code='"+empcd+"'", dbConn);
    
            dbConn.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
    
            context.Response.Write( Convert.ToBase64String((byte[])rdr["img"]) );
            }
            if (rdr != null)
             rdr.Close();
        }
        catch (Exception ex)
        {
    
        }
    }
