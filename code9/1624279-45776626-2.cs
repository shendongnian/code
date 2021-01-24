    private void MapTilesTest() {
      try {
        int testValue1 = (int)islandMapDataGridView[1, 1].Value;
        MessageBox.Show("Value is: " + testValue1.ToString());
      }
      catch (ArgumentOutOfRangeException ex) {
        MessageBox.Show("Cell 1,1 does not exist: total rows = " + islandMapDataGridView.Rows.Count + " total colums = " + islandMapDataGridView.Columns.Count);
      }
      catch (NullReferenceException ex) {
        MessageBox.Show("The 'Value' at Cell 1,1 is null (most likely the new row): total rows = " + islandMapDataGridView.Rows.Count + " total colums = " + islandMapDataGridView.Columns.Count);
      }
      catch (InvalidCastException ex) {
        MessageBox.Show("The 'Value' at Cell 1,1 is NOT a number or is an empty cell: actual cell value is: " + islandMapDataGridView[1, 1].Value.ToString());
      }
      catch (Exception ex) {
        MessageBox.Show("Some other error: " + ex.GetBaseException());
      }
    }
