    if (dataGridView1.Rows.Cast<DataGridViewRow>().All(c => c.Cells[0].Value.ToString() == null))
    {
        textbox.Text = "null";
    }
    else 
    {
        MessageBox.Show("No null"); 
    }
