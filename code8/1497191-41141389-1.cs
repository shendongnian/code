       private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name == "Column1"))
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    dataGridView1.CurrentCell = dataGridView1[1, 0];
                }));
            }
        }
