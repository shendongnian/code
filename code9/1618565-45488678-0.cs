            dataGridView1.DataSource = dTable;
            //Create the ComboBoxColumn at the end of the grid
            var cmb = new DataGridViewComboBoxColumn();
            cmb.Name = "ComboCol";
            cmb.HeaderText = "ComboCol";
            cmb.DataSource = new string[] { "a", "b", "c" };
            dataGridView1.Columns.Add(cmb);
            //UpdateDataSourceCombo();
