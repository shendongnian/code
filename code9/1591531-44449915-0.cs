    private void textBoxFilter_TextChanged(object sender, EventArgs e)
    {
        if(!string.IsNullOrWhiteSpace(textBox1.Text))
        {
            (dataGridViewFields.DataSource as DataTable).DefaultView.RowFilter = string.Format("Field = '{0}'", textBoxFilter.Text);
        }
    }
