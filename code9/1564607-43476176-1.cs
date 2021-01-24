    for (int y = 0; y < tlp.RowCount; ++y) {
      for (int x = 0; x < tlp.ColumnCount; ++x) {
        CheckBox cb = tlp.GetControlFromPosition(x, y) as CheckBox;
        if (cb != null) {
          MessageBox.Show(cb.Name);
        }
      }
    }
