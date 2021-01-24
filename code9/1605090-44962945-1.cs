        public string ParseRowText(DataGridView grid, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid.Rows[e.RowIndex];
            string output = "";
            for (int col = 0; col < grid.Columns.Count; col++)
            {
                //Get column header and cell contents
                output = output + grid.Columns[col].HeaderText + ": " + row.Cells[col].Value.ToString() + Environment.NewLine;
            }
            return output;
        }
