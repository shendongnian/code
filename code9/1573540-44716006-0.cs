        DataSet Music = new DataSet();
        Music= DBI.musicall();
        comboBox1.DisplayMember= "music1name";  
        comboBox1.ValueMember="Id";
        comboBox1.DataSource=Music.Tables[0];
    public static DataSet musicall()
    {
        SqlConnection connect= new SqlConnection(connectway);
        string sql = "select [music1.name] AS music1name from Music";
       SqlCommand command= new SqlCommand();
       command.CommandText=sql;
       command.Connection=connect;
        SqlDataAdapter adaptor = new SqlDataAdapter();
        adaptor.SelectCommand=command;
        DataSet finalDs= new DataSet();
        connect.Open();
        adaptor.Fill(finalDs);
        connect.Close();
        return finalDs;
    }
