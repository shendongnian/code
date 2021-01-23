    var dt = new DataTable();
    dt.Columns.Add("Id", typeof(int));
    dt.Columns.Add("Name", typeof(string));
    dt.Columns.Add("Date", typeof(DateTime));
    dt.Rows.Add(100, "A", DateTime.Now);
    dt.Rows.Add(200, "B", DateTime.Now.AddDays(1));
    dt.Rows.Add(300, "C", DateTime.Now.AddDays(2));
    dt.Rows.Add(400, "D", DateTime.Now.AddDays(3));
    this.dataGridView1.DataSource = dt;
    this.dataGridView2.DataSource = Rotate(dt);
    //To hide column headers and show Id,Name,Date on rows headers, un-comment following codes:
    //dataGridView2.ColumnHeadersVisible = false;
    //dataGridView2.Columns[0].Visible = false;
    //for (int i = 0; i < dataGridView2.Rows.Count; i++)
    //    dataGridView2.Rows[i].HeaderCell.Value = dataGridView2.Rows[i].Cells[0].Value;
