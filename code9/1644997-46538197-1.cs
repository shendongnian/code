      DataSet ds = new DataSet();
        SqlConnection myCon = new SqlConnection(connectionstring);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd, myCon);
        adapter.Fill(ds);
        DataView view = new DataView();
        view.Table = ds.Tables[0];
        view.RowFilter = "ColumnName = " + TextBox1.Text.Trim();
        GridView1.DataSource = view;
        GridView1.DataBind();
