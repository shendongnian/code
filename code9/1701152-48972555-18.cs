    private void FillComboBoxWithSheetNames() {
      cbWorksheetNames.Items.Clear();
      foreach (System.Data.DataTable dt in ds.Tables) {
        cbWorksheetNames.Items.Add(dt.TableName);
      }
    }
