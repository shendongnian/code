    DataTable dt = new DataTable();
    private void Form1_Load(object sender, EventArgs e)
    {
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Name");
        dt.Rows.Add(1, "X");
        dt.Rows.Add(10, "Y");
        dt.Rows.Add(100, "Z");
        this.dataGridView1.DataSource = dt;
    }
