    private void ComboboxInDatagridview()
    {
        var dataGridView1 = new DataGridView();
        DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
        combo.HeaderText = "FaultCodeByOp";
        combo.Name = "combo";          
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { combo });
        ArrayList list = new ArrayList() { "C-C", "C-O" };
        for (int rowCount = 0; rowCount < 5; rowCount++)
        {
            var rowindex = dataGridView1.Rows.Add();
            DataGridViewComboBoxCell cmbCell = (DataGridViewComboBoxCell)dataGridView1["combo", rowindex];
            cmbCell.DataSource = list;
        }
        //Disply dataGridView1 in windows form
        dataGridView1.Dock = DockStyle.Fill;
        panel1.Controls.Add(dataGridView1);
    }
