    private void button1_Click(object sender, EventArgs e)
    {
        var checkedValues = dataGridView1.Rows.Cast<DataGridViewRow>()
            .Where(row => (bool?)row.Cells["Your CheckBox Column Name"].Value == true)
            .Select(row => string.Format("{0}", row.Cells["The Other Column Name"].Value))
            .ToList();
        MessageBox.Show(string.Join(",", checkedValues));
    }
