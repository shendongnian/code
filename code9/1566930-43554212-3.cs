    //Get the values in the sheet
    object[,] valueArray = workSheet.Cells.GetValue<object[,]>();
    
    int maxRows = workSheet.Dimension.End.Row; 
    int maxColumns = workSheet.Dimension.End.Column;
    
    DataTable dt = new DataTable();
    
    //Column Headers
    for (int col = 0; col < maxColumns; col++)
    {
       dt.Columns.Add(valueArray[0,col]);
    }
    //Import Excel Data ot DataTable
    for (int row = 1; row < maxRows; row++)
    {
      DataRow dr = dt.NewRow();
      for (int col = 0; col < maxColumns; col++)
      {
          dr[col] = valueArray[row,col].ToString();
      }
      dt.Rows.Add(dr);
    }
    //Set the Column order
    dt.Columns["Claim Number"].SetOrdinal(0);
