    dataGridView1.CellBeginEdit += ( sender , e ) =>
    {
        var dataGridViewCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        if ( dataGridViewCell.ValueType == typeof(bool))
        {
            var checkedCount = dataGridViewCell.Tag is int ? ( int )dataGridViewCell.Tag : 0;
            e.Cancel = checkedCount == 3;
        }                
    };
    dataGridView1.CellEndEdit += ( sender , e ) =>
    {
        var dataGridViewCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
        if ( dataGridViewCell.ValueType == typeof(bool))
        {
            var checkedCount = dataGridViewCell.Tag is int ? ( int )dataGridViewCell.Tag : 0;
            dataGridViewCell.Tag = checkedCount + 1;
        }
    };
