    dataGridView1.AutoGenerateColumns = false;
    dataGridView1.Rows.Clear();
    listBox1.Items.Add("1");
    listBox1.Items.Add("2");
    listBox1.Items.Add("3");
    dataGridView1.Columns.Add("First","First");
            
    foreach (var item in listBox1.Items)
    {
        int idx = dataGridView1.Rows.Add();
                
        dataGridView1.Rows[idx].Cells["First"].Value = item;
                
    }
