    using(SqlConnection con = new SQLConnection(ConfigurationManager.ConnectionStrings["DeliveryCon"].ToString())
    {
        // other statements
        SqlCommand command2 = new SqlCommand("select LastName from Client WHERE Email= @x ", con);
        SqlParameter param = new SqlParameter(
        "@x", SqlDbType.NVarChar, 16);
        param.Value = Session["currentUser"];
        command2.Parameters.Add(param);
        con.Open();
        string y = command2.ExecuteScalar().ToString();
        con.Close();
        Session["currentUser"] = y;
    }
