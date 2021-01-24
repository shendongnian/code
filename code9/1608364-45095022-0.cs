       private void ComboboxInDatagridview()
            {
                var dataGridView1 = new DataGridView();
                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                combo.HeaderText = "FaultCodeByOp";
                combo.Name = "combo";
                combo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns.AddRange(new DataGridViewColumn[] { combo });
    
                List<string> list = new List<string>() { "--Select--", "C-C", "C-O" };
                for (int rowCount = 0; rowCount < 5; rowCount++)
                {
                    var index = dataGridView1.Rows.Add();
                    DataGridViewComboBoxCell cmbCell = (DataGridViewComboBoxCell)dataGridView1["combo", index];
                    cmbCell.DataSource = list;
                    cmbCell.Value = list[0];
                }
    
                //Disply dataGridView1 in windows form
                dataGridView1.Dock = DockStyle.Fill;
                panel1.Controls.Add(dataGridView1);
            }
