    using (SqlDataAdapter sda = new SqlDataAdapter())
    {
        comm.Connection = con;
        sda.SelectCommand = comm;
        DataTable dt = new DataTable();
        sda.Fill(dt);
        return dt;
    }
