    if(e.ColumnIndex == dataGridView.Columns["ColumnName"].Index)
    {
        var column1Index = dataGridView1.Columns[ "ColumnNameA" ].Index;
        var column2Index = dataGridView1.Columns[ "ColumnNameB" ].Index;
        if(dataGridView[column1Index, e.RowIndex].Value.ToString() == dataGridView[column2Index, e.RowIndex].Value.ToString())
        {
            //They match, remove color
        }
    }
