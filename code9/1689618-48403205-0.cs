    private void dataGridView1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            var column2Value = dataGridView1.GetFocusedRowCellValue(dataGridView1.Columns[1]);
            MessageBox.Show(column2Value.ToString())
        }        
    }
