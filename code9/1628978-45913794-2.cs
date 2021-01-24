c#
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
And in new version that I downloaded this must changed:
    cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
to:
    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
