    DataGridView dataGridView2 = new DataGridView();
    BindingSource bindingSource2 = new BindingSource();
    
    dataGridView2.ColumnCount = 2;
    
    dataGridView2.Columns[0].Name = "FieldOne";
    dataGridView2.Columns[0].DataPropertyName = "FieldOne";
    dataGridView2.Columns[1].Name = "FieldTwo";
    dataGridView2.Columns[1].DataPropertyName = "FieldTwo";
    
    bindingSource1.DataSource = GetDataTable();
    dataGridView1.DataSource = bindingSource1;
