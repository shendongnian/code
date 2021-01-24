    DataTable dt_ = new DataTable();
    
    DataTable table = new DataTable();
    //Get all the rows and change into columns
    for (int i = 0; i <= dt.Rows.Count; i++)
    {
        table.Columns.Add(dt.Rows[i][0]); // the column name is in the first cell
    }
    DataRow dr;
    //get all the columns and make it as rows
    for (int j = 0; j < dt.Columns.Count; j++)
    {
        dr = table.NewRow();
        dr[0] = dt.Columns[j].ToString();
        // changed the for condition
        for (int k = 1; k < dt.Rows.Count; k++)
        {
            dr[k] = dt.Rows[k][j]; // changed the 'k - 1' to 'k'
        }
    
        table.Rows.Add(dr);
    }
    
    dt_ = table;
