	using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString))
    {
        con.Open();
        var sql = "SELECT * FROM TBLPINOY WHERE BIRTHDAY BETWEEN TO_DATE('"+searchdate1.Text+"', 'DD/MM/YYYY') AND TO_DATE('"+searchdate2.Text+"', 'DD/MM/YYYY')";
		
        using (var cmd = con.CreateCommand())
        {
            OracleDataReader odr;
            cmd.CommandText = sql;
            odr = cmd.ExecuteReader();
            gv.DataSource = odr;
            gv.DataBind();
        }
    }
