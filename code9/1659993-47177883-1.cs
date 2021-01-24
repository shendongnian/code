    for(int i = 5; i >= 0; i--){
      if(i == 5)
      {
        for(int j = 0; j < dt.Columns.Count; j++)
          dt.Columns[j].ColumnName = dt.Rows[i][j].ToString();
      }
      dt.Rows.RemoveAt(i);
    }
