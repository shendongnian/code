    public static void RemoveNullColumnFromDataTable(DataTable dt, string[] columnName)
    {
        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            foreach (string column in columnName)
            {
                if (dt.Rows[i][column] == DBNull.Value)
                {
                    dt.Rows[i].Delete();
                }
            }
        }
        dt.AcceptChanges();
    }
