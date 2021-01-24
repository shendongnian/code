    public void SqlDbConnect()
    {
        SqlConnection conn = new SqlConnection(string.Format("Data Source={0};User ID={1};Password={2};", server, user, password));
        conn.Open();
    }
