            private void datagridview1_CellContentClick(Object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    if (row.Cells["up_hours"].Value == null)
                    {
                        dateTimePicker1.CustomFormat = " ";
                        dateTimePicker1.Format = DateTimePickerFormat.Custom;
                    }
                    else
                    {
                        dateTimePicker1.Format = DateTimePickerFormat.Long;
                        dateTimePicker1.Text = row.Cells["up_hours"].Value.ToString();
                    }
                }
            }
