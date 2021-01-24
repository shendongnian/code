    dataGridView1.AutoGenerateColumns = false;
    dataGridView1.Columns.Add("Col1", "Column1");
    dataGridView1.Columns.Add("Col2", "Column2");
    dataGridView1.Columns.Add("Col3", "Column2");
    .  .  . 
    
    dataGridView1.Columns["Col1"].DataPropertyName = "Col1NameFromSource";
    dataGridView1.Columns["Col2"].DataPropertyName = "Col2NameFromSource";
    dataGridView1.Columns["Col3"].DataPropertyName = "Col3NameFromSource";
    .  .  .
