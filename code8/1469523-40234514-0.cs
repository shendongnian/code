       private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in yourdataGridView.Rows)
            {
                //checked? 
                if (Convert.ToBoolean(row.Cells[CheckBoxIndex].Value))
                {
                    //update your_table set field = value where id = row.Cells["fieldname"].Value;
                   
                }
            }
        }
