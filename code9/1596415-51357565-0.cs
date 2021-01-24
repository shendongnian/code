        private DataTable ToDataTable(DataGridView dataGridView)
        {
            var dt = new DataTable();
            int columnCount = 0;
            List<int> columnNumbers= new List<int>();
            foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
            {
             
                if (dataGridViewColumn.Visible)
                {
                    dt.Columns.Add(dataGridViewColumn.Name);                   
                    columnNumbers.Add(columnCount);
                   
                }
                columnCount++;
            }
          
            var cell = new object[columnNumbers.Count];
            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                int i = 0;
                foreach (int a in columnNumbers)
                {
                    cell[i] = dataGridViewRow.Cells[a].Value;
                    i++;
                }
                dt.Rows.Add(cell);
            }
            return dt;
        }
