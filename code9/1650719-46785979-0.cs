    int minWidth = 40;
   
    private int YourMethodToGetColumnWidth() {
      return myDGV.Width / myDGV.Columns.Count;
    }
    private void SetColumnWidths() {
      int columnWidth = YourMethodToGetColumnWidth();
      if (columnWidth < minWidth)
        columnWidth = minWidth;
      foreach (DataGridViewColumn col in myDGV.Columns)
        col.Width = columnWidth;
      int allColumnsWidth = columnWidth * myDGV.Columns.Count;
      if (allColumnsWidth > myDGV.Width) {
        myDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
      }
      else {
        myDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      }
    }
