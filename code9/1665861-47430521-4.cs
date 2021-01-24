    try{
        int stageID  = 0;
        string strConnect = @"Database=Database_Name;Data Source=Your_Server_Name;Initial Catalog=Your_Db_Name;Integrated Security=True";
        using (SqlConnection con = new SqlConnection(strConnect))
        {
            con.Open();
            con.InfoMessage += new SqlInfoMessageEventHandler(con_InfoMessage);
        }
        SqlConnection Conn = new SqlConnection(Connection_String);
        SqlCommand Comm1 = new SqlCommand(Command, Conn);
        Conn.Open();
        SqlDataReader DR1 = Comm1.ExecuteReader();
        if (DR1.Read())
        {
            stageID   = Convert.ToInt32(DR1.GetValue(0));
        }
        Conn.Close();
    }
    catch(exception ex)
    {
    // your exceptio code
    }
