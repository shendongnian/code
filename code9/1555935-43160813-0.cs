    List<string> emails = new List<string>();
    foreach (DataGridViewRow row in dgvTest.Rows)
    {
      if (Convert.ToBoolean(row.Cells[cbSelect.Name].Value) == true)
      {
        //list to collect current row items
        var currentMailItems = new List<string>()
        foreach (DataGridViewCell cell in row.Cells)
        {
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
