    private void AddExcelRowToDataTable(Range usedRange, Range row, System.Data.DataTable dt) {
      if (usedRange.Columns.Count >= dt.Columns.Count - 1) {
        int rowIndex = GetRowIndexOfFoundItem(row);
        if (rowIndex >= 0) {
          DataRow dr = dt.NewRow();
          // add the CXRX data
          dr[0] = row.get_Address(true, true, XlReferenceStyle.xlR1C1);
          for (int i = 1; i <= usedRange.Columns.Count; i++) {
            dr[i] = usedRange.Cells[rowIndex, i].Value2;
          }
          dt.Rows.Add(dr);
        }
      }
    }
