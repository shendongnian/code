        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
            if (column.Name == "dateColumn")
            {
                UpdateStuff();
            }
        }
        private void UpdateStuff()
        {
            object myDate = dataGridView1.CurrentCell.Value;
        }
