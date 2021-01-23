    public int CheckIDVisitor(visitorName)
    {
        using (var sqlConn=new SqlConnection(Properties.Default.MyDbConnectionString))
        {
            string sql = "SELECT ID FROM Visitors WHERE name=@name"
            var result = conn.Query<int?>(sql, new { name = visitorName);
            return result??0;
        }
    }
