    if (dataGridView1.Rows.Cast<DataGridViewRow>().Any(c => c.Cells[0].Value?.ToString() == null))
    {
        textbox.Text = "null";
    }
    else 
    {
        MessageBox.Show("No null"); 
    }
