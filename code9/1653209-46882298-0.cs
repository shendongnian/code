    this.radGridView1.MasterTemplate.BeginUpdate();
    int count = this.radGridView1.SelectedCells.Count;
    for (int i = 0; i < count; i++)
    {
    	GridViewRowInfo row = this.radGridView1.SelectedCells[i].RowInfo;
    	GridViewColumn column = this.radGridView1.SelectedCells[i].ColumnInfo;
    	
    	string text = Convert.ToInt32(this.radGridView1.SelectedCells[i].ColumnInfo.HeaderText);
    	GridViewCellInfo cell = this.radGridView1.SelectedCells[i]; 
    	int val = Convert.ToDouble(cell.Value);
    }
    this.radGridView1.MasterTemplate.EndUpdate();
