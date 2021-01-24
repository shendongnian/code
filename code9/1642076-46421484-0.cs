    using(SqlConnection con = new SQLConnection(ConfigurationManager.ConnectionStrings["DeliveryCon"].ToString())
    {
        con.Open();
        // ~ other statements, including execute reader
        con.Close();
    }
