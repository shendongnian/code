    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        string search = txtSearch.Text;
        
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (row.Cells["Nugget Name"].Value != null)
            {
                string productName = row.Cells["Nugget Name"].Value.ToString();
                row.Visible = productName.ToLower().Contains(search.ToLower());
            }
        }
    }
