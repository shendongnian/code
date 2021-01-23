    using (OracleConnection cn = new OracleConnection("con string"))
    {
        cn.Open();
        OracleCommand cmd = new OracleCommand("ADD_USER");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = cn;
        cmd.Parameters.Add("YourSPParamName1", OracleDbType.{YourFieldTypeInDB}).Value = txtName.Text;
        cmd.Parameters.Add("YourSPParamName2", OracleDbType.{YourFieldTypeInDB}).Value = txtName2.Text;
        cmd.Parameters.Add("YourSPParamName3", OracleDbType.{YourFieldTypeInDB}).Value = txtID.Text;
        cmd.ExecuteNonQuery();
    }
