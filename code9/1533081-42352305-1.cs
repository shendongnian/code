    private void LoadDataToDgv()
    {
        using (IDbConnection dbconnection = new SQLiteConnection(conn))
        {
            dbconnection.Open();
            SQLiteDataAdapter dataadapter = new SQLiteDataAdapter("SELECT * FROM tbl_Sample",conn);
            DataSet ds = new System.Data.DataSet();
            dataadapter.Fill(ds,"Info");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
