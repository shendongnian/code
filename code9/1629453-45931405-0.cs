        private void dataGridView1_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            int columnToCheck = 0;//The index of the property/field/column you want to check
            if (e.ColumnIndex == columnToCheck)
            {
                using (var DB = new DataContext())
                {
                    if (DB.YourTable.Where(v => v.id == dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()).Count > 0)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        MessageBox.Show("This key already exists");
                        //Return the error message to your javascript in asp.net here
                    }
                }
            }
        }
