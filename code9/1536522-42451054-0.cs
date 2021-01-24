    DataSet dataSet = new DataSet("newexample");
    SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from newexample", connectionString);
    dataAdapter.Fill(dataSet);
       if (dataSet != null)
       {
        if (dataSet.Tables[0].Rows.Count != 0)
        {
            GridView1.DataSource = dataSet ;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
