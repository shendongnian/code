    Dictionary<string, int> dictionary = new Dictionary<string, int>();
    public void Form3_Load(object sender, EventArgs e)
    {
        dictionary["A"] = 1;
        dictionary["B"] = 2;
        dictionary["C"] = 3;
        var dt = new DataTable();
        dictionary.Keys.ToList().ForEach(x => dt.Columns.Add(x, typeof(int)));
        dt.Rows.Add(dictionary.Values.Cast<object>().ToArray());
        this.dataGridView1.DataSource = dt;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        var dt = this.dataGridView1.DataSource as DataTable;
        dt.Columns.Cast<DataColumn>().ToList()
            .ForEach(x=>dictionary[x.ColumnName]= dt.Rows[0].Field<int>(x.ColumnName));
    }
