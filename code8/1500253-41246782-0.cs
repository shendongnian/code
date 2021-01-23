    using (OracleConnection conn = new OracleConnection(connstr))
    using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
    {
        conn.Open();
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        CBOfficeCode.DataSource = dt;
        CBOfficeCode.DisplayMember = "Column1";
        CBOfficeCode.ValueMember = "Column2";
    }
