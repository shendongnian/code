        using (var con = new SqlConnection(ConStr))
    {
        string query = "SELECT * FROM CHECKINOUT";
        using (var cmd = new SqlCommand(query, con))
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
    
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
    }
        int lastRow = 0;
        lastRow = ds.Tables(0).rows.count - 1;
        
        string col1 = ds.Tables(0).Rows(lastRow)(0).tostring.trim;
        string col2 = ds.Tables(0).Rows(lastRow)(1).tostring.trim;
        string col3 = ds.Tables(0).Rows(lastRow)(2).tostring.trim;
