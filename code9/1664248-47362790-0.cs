    for (int i = 9; i < dt.Columns.Count; i++)
    {
        if(!DBNull.Value.Equals(dt.Columns[i].ColumnName))
        {
            string dtcolumn = dt.Columns[i].ColumnName.ToString();
            dt.Rows[dt.Rows.Count - 1][i] = Convert.ToInt32(dt.Compute("SUM( " + dtcolumn + " )", "  " + dtcolumn + " > 0"));
         } 
     }
