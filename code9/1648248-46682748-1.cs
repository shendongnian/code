    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex]; //Get selected Row
        string[] selectedValues = new string[selectedRow.Cells.Count]; //Init string array or list, or custom object array/list
        for (int i = 0; i < selectedRow.Cells.Count; i++)
        {
            selectedValues[i] = selectedRow.Cells[i].Value.ToString(); //Fill your array with cell values
        }
        //Your next code goes here
    }
