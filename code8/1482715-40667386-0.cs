        private DataTable ConvertListToDataTable(List<double[]> list)
        {
            DataTable table = new DataTable();
            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }
            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                // Provide default column name & data type
                table.Columns.Add("Column" + (i+1).ToString(), typeof(double) );
            }
            // Add rows.
            foreach (var array in list)
            {
                // assign each array element to the appropriate column
                var row = table.NewRow();
                for (int i = 0; i < array.Length; ++i )
                    row.SetField( i, array[i] );
                table.Rows.Add(row);
            }
            return table;
        }        
