    dataGridView1.DataSource = dt;
    var checkBox = new DataGridViewCheckBoxColumn
    {
        Name = "checkBox",
        HeaderText = @"checkBox",
        Width = 70
    };
    //Set other properties...
    dataGridView1.Columns.Insert(1, checkBox);
