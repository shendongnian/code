    // storing header part in Excel 
    foreach (DataColumn dc in dtFiltered.Columns)
    {
        worksheet.Cells[1, i] = dc.ColumnName);
    }
    int j=1;
    foreach (DataRow dr in dtFiltered.Rows) 
    { 
       j++;
       for (int i = 0; i < dtFiltered.Columns.Count; i++)              
       { 
           worksheet.Cells[j, i + 1] =  dr[i].ToString()); 
        }
    }
