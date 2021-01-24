        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dg = sender as DataGridView;
            foreach (DataGridViewRow item in dg.Rows)
            {
                //your condition
                int id = Convert.ToInt32(item.Cells[0].Value);
                if (id == 1)
                {
                    dg.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
            }
        }
