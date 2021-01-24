    Dataframe dataset = engine.evaluate ("some dataframe"). AsDataframe ();
    DataTable dtable = new DataTable ();
    For (int i = 0; i <dataset.ColumnCount; ++ i)
    {
       Dtable.Columns.Add (dataset.ColumnNames [i]);
    }
    For (int i = 0; i <dataset.RowCount; i ++)
    {
       DataRow newRow = Dtable.Rows.Add();
       For (int j = 0; j <dataset.ColumnCount; j ++)
       {
          newRow[j] = dataset [i, j];
       }
    }
