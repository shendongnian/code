    for (int y = 0; y < tlp.RowCount; ++y) {
      for (int x = 0; x < tlp.ColumnCount; ++x) {
        MessageBox.Show(tlp.GetControlFromPosition(x, y).Name);
      }
    }
