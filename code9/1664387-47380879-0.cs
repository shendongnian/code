    string insert = "insert into my_table values (:COMPTE, :MO, :USERIMP)";
    using (OracleCommand cmd = new OracleCommand(insert, Connection))
    {
        // no ":" in the parameter declarations
        cmd.Parameters.Add(new OracleParameter("COMPTE", OracleDbType.Int32));
        cmd.Parameters.Add(new OracleParameter("MO", OracleDbType.Varchar2));
        cmd.Parameters.Add(new OracleParameter("USERIMP", OracleDbType.Varchar2));
        cmd.Parameters[0].Value = 123;
        cmd.Parameters[1].Value = "ubs";
        cmd.Parameters[2].Value = "22.10.17";
        cmd.ExecuteNonQuery();
    }
