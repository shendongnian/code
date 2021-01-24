    //declared somewhere above
    List<string> CellsForReport = new List<string>{ "item1", "item2", "item3", "item4" }
    //code inside buttonReport_Click
    List<string> emails = new List<string>();
    foreach (DataGridViewRow row in dgvTest.Rows)
    {
      if (Convert.ToBoolean(row.Cells[cbSelect.Name].Value) == true)
      {
        //list to collect current row items
        var currentMailItems = new List<string>()
        foreach (var cellName in CellsForReport )
        {
           //this can throw exception if you specified wrong name above
           var cell = row.Cells[cellName];
           if (cell.Value != null)
           {
             currentMailItems.Add(cell.Value.ToString());
           }
        }
        //construct email text from row
        var finalEmailText = string.Join(", ", currentMailItems);
        emails.Add(finalEmailText);
      }
    }
    //sending 1 email per row
    foreach (var email in emails)
    {
      SendEmail("Hi!", from, to, email);
    }
