        DataRow dr = null;
        for (int i = 0; i < queue.Tables[0].Columns.Count; i++)
        {
           dr = missedQueue.NewRow();
           dr[queue.Tables[0].Columns[i].ColumnName] = queue.Tables[0].Rows[0][i]; 
           missedQueue.Rows.Add(dr);
        }
