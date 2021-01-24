    for (int i = 0; i < finalTable.Rows.Count; i++)
    {
        for (int r = 0; r < filesTable.Rows.Count; i++)
        {
            if (finalTable.Rows[r].Field<string>(2) == filesTable.Rows[r].Field<string>(2))
            {
                finalTable.Rows.Remove(finalTable.Rows[i]);
            }
        }
    }
