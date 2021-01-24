    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex == 1 && e.RowIndex == 2)
                {
                    var dialog = new OpenFileDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView1[e.ColumnIndex, e.RowIndex].Value = dialog.FileName;
                    }
                }
            }
