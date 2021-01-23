    foreach (DataGridViewRow row in b1.DataGridView1.SelectedRows)
    {
       string value = row.Cells[4].Value.ToString();
       double currentCellValue = 0.0;  
       if(double.TryParse(value , out currentCellValue)
       { 
          totalCost += currentCellValue;
       }
     }
    TotalCost.Text = totalCost .ToString();
