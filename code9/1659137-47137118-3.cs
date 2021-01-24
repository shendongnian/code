    // storing header part in Excel 
    int i=0;
    foreach (DataColumn dc in dtFiltered.Columns)
    {
        i++;
        worksheet.Cells[1, i] = dc.ColumnName);
    }
    int j=1;
    foreach (DataRow dr in dtFiltered.Rows) 
    { 
       j++;
       for (i = 0; i < dtFiltered.Columns.Count; i++)              
       { 
           worksheet.Cells[j, i + 1] =  dr[i].ToString()); 
        }
    }
