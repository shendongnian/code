    public int CheckIDVisitor(visitorName)
    {
        string query = "SELECT ID FROM Visitors where Name=@name";
        using (var sqlConn=new SqlConnection(Properties.Default.MyDbConnectionString))
        using( var cmd=new SqlCommand(query,sqlConn))
        {
            var cmdParam=cmd.Parameters.Add("@name",SqlDbType.NVarChar,20);
            cmdParam.Value=visitorName;
            sqlConn.Open();
            var result=(int?)cmd.ExecuteScalar();
            return result??0;
        }
    }
