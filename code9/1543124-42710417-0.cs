    private DataTable Transpose2ColDT(DataTable dtSource) {
      string prefix = "DIAP_";
      string colName = "";
      DataTable dtResult = new DataTable();
      List<string> valuesList = new List<String>();
      if (dtSource.Rows.Count > 0) {
        foreach (DataRow dr in dtSource.Rows) {
          if (!dr.IsNull("Label")) {
            if (dr.ItemArray[1].ToString() != "" ) {
              colName = prefix + "_" + dr.ItemArray[1].ToString();
              if (!dtResult.Columns.Contains(colName)) {
                dtResult.Columns.Add(colName, typeof(string));
                valuesList.Add(dr.ItemArray[0].ToString());
              }
            }
          }
        }
        dtResult.Rows.Add(valuesList.ToArray<string>());
      } // no rows in the original source
      return dtResult;
    }
