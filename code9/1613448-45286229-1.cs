    int allDValuecount = 0;
    int allOtherValueCount = 0;
    int rowsCount = DataGridViewRow.Rows.Cont;
    foreach(DataGridViewRow row in DataGridViewRow.Rows)
    {
        if(!row.Cells[3].Value.ToString().Equals("D"))
        {
            allOtherValueCount++;
        }else
        {
            allDValuecount++;
        }
    }
    if(allDValuecount == rowsCount){//code for all D values}
    if(allOtherValueCount == rowsCount){//code for other values}
