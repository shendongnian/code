    for (int r = 1; r <= r1.Rows.Count; r++)
    {
        for (int c = 1; c <= r1.Columns.Count; c++)
        {
            r2[r, c].AddComment(r1.Comment);
        }
    }
