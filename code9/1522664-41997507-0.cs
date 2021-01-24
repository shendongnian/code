    for (int i = 0; i < table.Rows.Count; i++)
    {
        var row1 = table.Rows[i].Items[0]
        foreach (DataRow dr in csv_datatable.Rows)
        {
            if (row1.ToString().Equals(dr.Items[0].ToString()))
            {
                csv_datagridview.Rows[i].Cells[0].Style.BackColor = Color.Red;
                break; 
            }
         }
     }
