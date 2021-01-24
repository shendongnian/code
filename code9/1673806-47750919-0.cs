                if (!string.IsNullOrEmpty(comboBox1.Text))
                {
                    var dt = (DataTable)dgvpayslip.DataSource;
                    dt.DefaultView.RowFilter = string.Format("{0} like '%{1}%'",comboBox1.Text.Trim().Replace("'", "''"), txtkeyword.Text.Trim().Replace("'", "''"));
                    dgvpayslip.Refresh();
                }
