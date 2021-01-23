    public void InitVisitorCommand()
    {
        string query = "SELECT ID FROM Visitors where Name=@name";
        var cmd=new SqlCommand(query,sqlConn);
        var cmdParam=cmd.Parameters.Add("@name",SqlDbType.NVarChar,20);
        _myVisitorCommand=cmd;
    }
    ...
    public int CheckIDVisitor(visitorName)
    {
        using (var sqlConn=new SqlConnection(Properties.Default.MyDbConnectionString))
        {
            _myVisitorCommand.Parameters.["@name"]Value=visitorName;
            _myVisitorCommand.Connection=sqlConn;
            sqlConn.Open();
            var result=(int?)cmd.ExecuteScalar();
            return result??0;
        }
    }
