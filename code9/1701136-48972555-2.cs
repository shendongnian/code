    private void btnSearch_Click(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(tbSearch.Text)) {
        MessageBox.Show("Enter text for search");
        return;
      }
      if (workbook == null) {
        MessageBox.Show("Select a workbook");
        return;
      }
      ds = new DataSet();
      try {
        ds = GetRowsFromSearchStringFromAllWorksheets(workbook, tbSearch.Text);
        DGV_Data.DataSource = ds.Tables[0];
        FillComboBoxWithSheetNames();
        cbWorksheetNames.SelectedIndex = 0;
        gbResults.Text = "Search Results for '" + tbSearch.Text + "'";
        tbSearch.Text = "";
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex.Message);
      }
    }
