    int y = 0;
    var checkItem = gridreq.Rows[0].Cells[2].Text;
    foreach (GridViewRow row in gridreq.Rows)
    {
        string catid = row.Cells[2].Text;
        if (catid == checkItem)    //or use String.compare here
        {
            y = y + 1;
    
        }
    }
