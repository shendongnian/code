    var dt = new DataTable();
    dt.Load(rd);
    foreach (DataRow row in dt.Rows)
    {
        // other stuff
        try
        {
            SqlCommand cmd2 = new SqlCommand(qry2, cn);
            cmd2.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            // throw exception
        }
    }
