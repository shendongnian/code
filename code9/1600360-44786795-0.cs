    private DataTable InsertABlankRow(DataTable dt)
        {
            int n = dt.Rows.Count;
            DataTable dtnew = dt.Copy();
            if (dt.Columns.Contains("colname"))
            {
                var countRows = dt.Select("colname ='xyz'").Length;
    
                if (countRows > 1)
                {
                    foreach (DataRow drow in dtnew.Rows)
                    {
                        if (drow["colname"].ToString() == "xyz")
                        {
                            int index = dt.Rows.IndexOf(drow);
                            dt.Rows.InsertAt(dt.NewRow(), index + 1); 
                            
                        }
                    }
                  dt.AcceptChanges();
                }
            }
    return dt;
    }
