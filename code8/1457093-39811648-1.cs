    foreach (Range row in rng.Rows)
    {
        foreach (Range column in row.Columns)
        {
            if (column.Value == "test")
            {
                column.Interior.Color = Color.Red;
            }
        }
    }
