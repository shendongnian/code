     foreach (DataRow item in dt.Rows)
                {
                    DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(add you data grid viwe cell index here);
                    ContactCombo.DataSource = // your contacts datasource;
                    ContactCombo.DisplayMember = "name of field to be displayed like say ContactName";
                    ContactCombo.ValueMember = "Id";
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
