       private void btnUpdate_Click(object sender, EventArgs e)
        {
             
            foreach (DataGridViewRow row in yourdataGridView.Rows)
            {
                var comboValue = string.IsNullOrEmpty(row.Cells[ComboBoxColumnName.Index].Value.ToString()) ? "" : row.Cells[ComboBoxColumnName.Index].Value.ToString();
                if (some logic here to update)
                {
                    //update your_table set field = value where id = row.Cells["fieldname"].Value;
                   
                }
            }
        }
