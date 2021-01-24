    private DataTable GetNColumnsFromDataTable(DataTable tblSource, int outputCols)
        {
            DataTable columnOutput = tblSource.Copy();
            if (outputCols > 0 && outputCols < tblSource.Columns.Count)
            {
                while (outputCols < columnOutput.Columns.Count)
                {
                    columnOutput.Columns.RemoveAt(columnOutput.Columns.Count - 1);
                }
            }
            return columnOutput;
        }
