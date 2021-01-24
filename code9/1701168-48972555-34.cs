    private System.Data.DataTable GetDTColumnsFromWorksheet(Worksheet ws) {
      // this assumes that row 1 of the worksheet contains a row header
      // we will use this to name the `DataTable` columns
      // this also assumes there are no "lingering" cells with values
      // that may not necessarily belong to the data table
      int missingColumnNameCount = 1;
      Range usedRange = ws.UsedRange;
      int numberOFColumns = usedRange.Columns.Count;
      System.Data.DataTable dt = new System.Data.DataTable();
      dt.TableName = ws.Name;
      string currentColumnHeader = "";
      Range row1;
      // add an extra column in the front
      // this column will show where (RXCX) the found item is in the worksheet
      dt.Columns.Add("CXRX", typeof(string));
      for (int i = 1; i <= numberOFColumns; i++) {
        row1 = usedRange[1, i];
        if (row1.Value2 != null) {
          currentColumnHeader = row1.Value2.ToString();
        }
        else {
          // if the row has no value a default name and indexer to avoid duplicate column names
          currentColumnHeader = "???" + missingColumnNameCount;
          missingColumnNameCount++;
        }
        dt.Columns.Add(currentColumnHeader, typeof(string));
      }
      return dt;
    }
