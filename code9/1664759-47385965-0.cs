    string bFilter = "";
    string cFilter = "";
    
    private string CombinFilters()
    {
    	var a = new[] { bFilter, cFilter }; //all filters to combin
    	var notNull = a.Where(x => !string.IsNullOrWhiteSpace(x));
    	
    	if (notNull.Any())
    		return string.Join(" AND ", notNull);
    	else
    		return null;
    }
    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
    	DataView dv = new DataView(table);
    	bFilter = string.Format("[Nom complet] LIKE '%{0}%'", "123");
    	dv.RowFilter = CombinFilters();
    	dataGridView1.DataSource = dv;
    }
    
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
    	DataView dv = new DataView(table);
    	cFilter = string.Format("[Type programme] LIKE '%{0}%'", "345");
    	dv.RowFilter = CombinFilters();
    	dataGridView1.DataSource = dv;
    }
