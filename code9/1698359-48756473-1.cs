    DataTable dt = new DataTable();
    using (var con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\gregg\Desktop\KFC\Data.mdf; Integrated Security = True; Connect Timeout = 30"))
    {     
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        da.Fill(dt);
        DataGrid1.DataSource = dt;
    }
