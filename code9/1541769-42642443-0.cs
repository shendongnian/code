    private void DeleteParentRowsWithNoChilds(DataTable dt)
            {
                DataRow[] FolderRows;
                FolderRows = dt.Select("IsFolder='true'");
                foreach (DataRow row in FolderRows)
                {
                    int RowId = int.Parse(row["Id"].ToString());
                    int nextRowid = RowId + 1;
                    DataRow[] nextrow = dt.Select("Id='" + nextRowid + "'");
                    if (nextrow.Count() > 0 && !nextrow[0].ToString().Contains('\\'))
                    {
                        dt.Rows.Remove(row);
    
                    }
                    //If it is a last row
                    else
                    {
                        dt.Rows.Remove(row);
                    }
                  
                }
                    Session["dt"] = dt;
           }
