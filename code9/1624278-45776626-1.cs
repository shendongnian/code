    private void MapTilesTest() {
      try {
        // make sure there are enough rows
        if (islandMapDataGridView.Rows.Count < 2) {
          MessageBox.Show("Row Index is out of range: total rows = " + islandMapDataGridView.Rows.Count);
          return;
        }
        // make sure ther are enough columns
        if (islandMapDataGridView.Columns.Count < 2) {
          MessageBox.Show("Column Index is out of range: total columns = " + islandMapDataGridView.Columns.Count);
          return;
        }
        // make sure the cells value is not null
        if (islandMapDataGridView[1, 1].Value == null) {
          MessageBox.Show("Value is null (most likely the new row)");
          return;
        }
        // Make sure the cells value is actually an integer
        int testValue1 = 0;
        if (int.TryParse(islandMapDataGridView[1, 1].Value.ToString(), out testValue1)) {
          MessageBox.Show("Valid Value is: " + testValue1.ToString());
        }
        else { // everything is ok get the cells value
          MessageBox.Show("Value is not a number: " + islandMapDataGridView[1, 1].Value.ToString());
        }
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex.Message);
      }
    }
