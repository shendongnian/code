    // select FieldName,FieldValue from AttImportDetail where AttImportID =1
        private DataTable GenerateTransposedTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();
            DataTable distinct = inputTable.DefaultView.ToTable(true, "FieldName"); // get unique column name
            int Columns = distinct.Rows.Count; // get unique column count 
            int rows = inputTable.Rows.Count / distinct.Rows.Count; // count no of rows
            //  create datatable with unique column name 
            foreach (DataRow inRow in distinct.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }
            for (int i = 0; i < rows; i++)
            {
                DataRow newRow = outputTable.NewRow();
                for (int c = 0; c < outputTable.Columns.Count; c++)
                {
                    int rowsCount = i*outputTable.Columns.Count + c;
                    string colValue = inputTable.Rows[rowsCount]["FieldValue"].ToString();
                    string FieldName = inputTable.Rows[rowsCount]["FieldName"].ToString();
                    newRow[FieldName] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }
            return outputTable;
        }
