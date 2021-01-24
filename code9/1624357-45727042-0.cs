    DataTable dt = new DataTable();
    dt.Columns.Add("Factor1");
    dt.Columns.Add("Factor2");
    dt.Columns.Add("Result");
     
    for(int i=2; i<=9; i++)
    {
      for (int j=1; j<=10; j++)
      {
        dt.Rows.Add(i, j, i*j);
      }
    }
    
    GridView1.DataSource = dt;
    GridView1.DataBind();
