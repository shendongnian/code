    [WebMethod]
    public static string GetCnorGSTNo(string cnorName)
    {
        using (var con = new SqlConnection("connection-string here"))
        using (var cmd = new SqlCommand("select TinNo1 from CnorMaster where CnorName = @CnorName", con))
        {
            cmd.Parameters.Add("@CnorName", SqlDbType.NVarChar).Value = cnorName;
            con.Open();
            object val = cmd.ExecuteScalar();
            return val == DBNull.Value ? "" : (string)val;
        }
    }
