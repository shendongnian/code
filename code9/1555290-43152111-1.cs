    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
      if (e.ColumnIndex == 0) {
        tbShortestTime.Text = GetShortestTime();
        //DataGridViewColumn sortCol = dataGridView1.Columns[0];
        //dataGridView1.Sort(sortCol, ListSortDirection.Ascending);
      }
    }
    private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
      tbShortestTime.Text = GetShortestTime();
      //DataGridViewColumn sortCol = dataGridView1.Columns[0];
      //dataGridView1.Sort(sortCol, ListSortDirection.Ascending);
    }
    private string GetShortestTime() {
      string lowestString = "999:23:59";
      for (int i = 0; i < dataGridView1.Rows.Count; i++) {
        DataGridViewRow curRow = dataGridView1.Rows[i];
        if (!curRow.IsNewRow && curRow.Cells[0].Value != null) {
          lowestString = GetLowerTimeString(lowestString, curRow.Cells[0].Value.ToString());
        }
      }
      return lowestString;
    }
    private string GetLowerTimeString(string inTime1String, string inTime2String) {
      if (inTime1String.Length >= 8 && inTime1String.Length >= 8) {
        string time1String = inTime1String.Substring(inTime1String.Length - 8, 8);
        string time2String = inTime2String.Substring(inTime2String.Length - 8, 8);
        TimeSpan t1 = new TimeSpan();
        TimeSpan t2 = new TimeSpan();
        TimeSpan.TryParse(time1String, out t1);
        TimeSpan.TryParse(time2String, out t2);
        if (t1 < t2)
          return time1String;
        if (t1 > t2)
          return time2String;
        return time1String;
      }
      else {
        if (inTime1String.Length > inTime2String.Length)
          return inTime2String;
        else
          return inTime1String;
      }
    }
