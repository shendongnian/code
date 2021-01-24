    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn(false);
    chk.HeaderText = "CheckAll";
    chk.Name = "checkboxColumn";
    chk.ReadOnly = true;
    this.dataGridView1.Columns.Add(chk);
    this.dataGridView1.CellClick += DataGridView1_ToggleAll;
----------
    private void DataGridView1_ToggleAll(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewCheckBoxColumn col = this.dataGridView1.Columns[e.ColumnIndex] as DataGridViewCheckBoxColumn;
        if (col?.Name == "checkboxColumn")
        {
            bool checkAll = (bool)col.DefaultCellStyle.NullValue;
            col.HeaderText = checkAll ? "CheckAll" : "UncheckAll";
            col.DefaultCellStyle.NullValue = !checkAll;
        }
    }
