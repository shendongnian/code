    List<string> values = new List<string>();
    foreach (DataGridViewRow row in dataGridView1.Rows) {
        bool isSelected = Convert.ToBoolean(row.Cells["Column1"].Value);
        if (isSelected) {
            values.Add(row.Cells["pk_pspatitem"].Value.ToString());
        }
    }
    string message = String.Join(", ", values);
    MessageBox.Show(message);
