        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (this.MainForm.dataGridView1.Columns[e.ColumnIndex].Name == "Check" && e.RowIndex != -1)
                {
                    //here should be a code for enable/disable button, for ex
                    this.MainForm.btnUpdate.Enabled = !this.MainForm.btnUpdate.Enabled;
                }
            }
