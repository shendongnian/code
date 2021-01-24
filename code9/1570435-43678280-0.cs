    DataTable dt = new DataTable();
    dt.Columns.Add("Date");
    dt.Columns.Add("Smørrebrød");
    dt.Columns.Add("Minismørrebrød");
    dt.Columns.Add("Buffet");
    dt.Columns.Add("Daily Orders");
    
    DataGridView grid = new DataGridView();
    grid.DataSource = dt;
    grid.Width = 1000;
    Controls.Add(grid);
    grid.Columns[0].Width = 10;
