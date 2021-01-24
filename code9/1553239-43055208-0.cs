        DataRow dr = tbl.NewRow();
        dr[0] = file;
        for (int cIndex = 1; cIndex + 1 < tbl.Columns.Count; cIndex++)
        {
            dr[cIndex + 1] = cols[cIndex];
        }
        //  Now that it's populated, add it to the table. 
        tb.Rows.Add(dr);
