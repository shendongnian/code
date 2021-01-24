    private void FillTableWithSearchResults(Range usedRange, string searchString, System.Data.DataTable dt) {
      Range currentRange;
      if (usedRange.Rows.Count > 0) {
        Range startRange = usedRange.Find(searchString);
        if (startRange != null) {
          currentRange = usedRange.FindNext(startRange);
          AddExcelRowToDataTable(usedRange, startRange, dt);
          string startAddress = startRange.get_Address(true, true, XlReferenceStyle.xlR1C1);
          while (!currentRange.get_Address(true, true, XlReferenceStyle.xlR1C1).Equals(startAddress)) {
            AddExcelRowToDataTable(usedRange, currentRange, dt);
            currentRange = usedRange.FindNext(currentRange);
          }
        }
      }
    }
