      private DataTable CreateResultDataTable()
        {
            DataTable Result = new DataTable();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cell = row.Cells[1].Value;
                if(cell!=null){
                Result.Columns.Add(cell.ToString()); // why is Value null here ??
               }
            }
            return Result;
        }
