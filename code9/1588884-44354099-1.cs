    for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
    {
          DataRow dr = ds.Tables[0].Rows[i]; //One result line in your set
          //DataRow contains n columns
          for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
          {
             string someEntry = dr[i].ToString();
          }
    }
