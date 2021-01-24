    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
      cb_KPI.DataSource = SetKPI_ValuesForComboBox(AllDataTables.Tables[tabControl1.SelectedIndex]);
    }
    private List<string> SetKPI_ValuesForComboBox(DataTable dt) {
      List<string> kpiList = new List<string> {
        "All"
      };
      foreach (DataRow row in dt.Rows) {
        if (!kpiList.Contains(row["KPI"].ToString()))
          kpiList.Add(row["KPI"].ToString());
      }
      return kpiList;
    }
  
