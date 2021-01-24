        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && dataGridView1["Key", e.RowIndex].Value?.ToString() == "SomePathKey")
            {
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1["Value", e.RowIndex].Value = dialog.FileName;
                }
            }
        }
