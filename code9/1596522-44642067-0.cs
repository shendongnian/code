    private void Button_Click(object sender, EventArgs e)
    {    
        string message = "";
    
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            bool isSelected = Convert.ToBoolean(row.Cells["Column1"].Value);
            if (isSelected)
            {
                message += row.Cells["pk_pspatitem"].Value.ToString() + ", ");
            }
        }
        MessageBox.Show(message.Substring(0, message.Length - 2));
    }
