            // get the list of columns to remove
            List<DataColumn> dataColumnsToRemove = dt.Columns.Cast<DataColumn>().Where(c => c.Ordinal < nDataTableColWriteStart).ToList();
            // copy the DataTable
            DataTable dtSubset = dt.Copy();
            // remove unwanted columns
            foreach (DataColumn col in dataColumnsToRemove)
            {
                dtSubset.Columns.Remove(col.ColumnName);
            }
