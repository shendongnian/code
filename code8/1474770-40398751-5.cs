    public int[] CheckIDVisitors(string []visitors)
    {
        using (var sqlConn=new SqlConnection(Properties.Default.MyDbConnectionString))
        {
            string sql = "SELECT ID FROM Visitors WHERE name IN @names"
            var results = conn.Query<int?>(sql, new { names = visitors);
            return results.ToArray();
        }
    }
