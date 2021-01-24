                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    for (int k = 9; k < dt.Columns.Count; k++)
                    {
                        if (dt.Rows[j][k].ToString() == "")
                        {
                            dt.Rows[j][k] = "0";
                        }
                    }
                }
                
         for (int i = 9; i < dt.Columns.Count; i++)
            {
            string dtcolumn = dt.Columns[i].ColumnName.ToString();
            dt.Rows[dt.Rows.Count - 1][i] = Convert.ToInt32(dt.Compute("SUM( " + dtcolumn + " )", "1 > 0"));
             }
