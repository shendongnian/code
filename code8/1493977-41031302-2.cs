    using (var cn = new MySqlDbConnection("your connection string here"))
    using (var cmd = new MySqlDbCommand("DELETE * from `MYTABLE` WHERE MyIDColumn = @rowKey;")) // Note that I removed the single quotes (')
    {
        cmd.Parameters.Add("@rowKey", MySqlDbType.Int32);
        cn.Open();
        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
        {
            if (!row.IsNewRow)
            {
                //not sure which cell(s) in the grid make up your primary key
                cmd.Parameters["@rowKey"].Value = Convert.ToInt32(row.Cells[0]);
                cmd.ExecuteNonQuery();
                dataGridView1.Rows.Remove(row);
            }        
        }    
    }
    MessageBox.Show("Selected rows Deleted");
