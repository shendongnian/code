    var query = new[] { new { Date = new DateTime(2016,10,21,10,0,0), Value = 6 },
    					new { Date = new DateTime(2016,10,21,10,15,0), Value = 9 },
    					new { Date = new DateTime(2016,10,30,10,0,0), Value = 18 }};
    var groupedQuery = query.GroupBy(p => p.Date.Date, p => p.Value, (key, g) => new { Date = key, Value = g.Sum() });
    var grid = new DataGridView();
    var bs = new BindingSource();
    bs.DataSource = groupedQuery;
    grid.AutoGenerateColumns = false;
    grid.DataSource = bs;
    foreach (var item in groupedQuery)
    {
    	DataGridViewColumn column = new DataGridViewColumn { HeaderText = item.Date.Date.ToString() };
    	grid.Columns.Add(column);
    }
