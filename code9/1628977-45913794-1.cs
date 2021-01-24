    I Converted this:
    //Adding DataRow
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        foreach (DataGridViewCell cell in row.Cells)
        {
            pdfTable.AddCell(cell.Value.ToString());
        }
    }
    TO:
    //Adding DataRow
           
    
     foreach (DataGridViewRow row in dataGridView1.Rows)
     {
          foreach (DataGridViewCell cell in row.Cells)
          {
               try
               {
                   pdfTable.AddCell(cell.Value.ToString());
               }
               catch { }
           }
     }
