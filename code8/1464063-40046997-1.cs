    private void dataGridView1_ColumnHeaderMouseClick(object sender, 
                               DataGridViewCellMouseEventArgs e)
    {
        List<Name> names = dataGridView1.DataSource as List<Name>;
        string col = dataGridView2.Columns[e.ColumnIndex].DataPropertyName;
        string order =  " ASC";
        if (dataGridView1.Tag != null) 
            order = dataGridView1.Tag.ToString().Contains(" ASC") ? " DESC" : " ASC";
                
        dataGridView1.Tag = col + order;
        if (order.Contains(" ASC"))
        names = names.OrderBy(x => col == "first"? x.first 
                                 : col == "last" ? x.last : x.middle).ToList();  
        else
        names = names.OrderByDescending(x => col == "first"? x.first : 
                                             col == "last" ? x.last : x.middle).ToList();  
        dataGridView1.DataSource = names;
    }
