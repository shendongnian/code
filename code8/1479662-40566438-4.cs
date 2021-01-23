    Dictionary<string, int> dictionary;
    public void Form3_Load(object sender, EventArgs e)
    {
        dictionary = new Dictionary<string, int>() { { "A", 1 }, { "B", 2 }, { "C", 3 } };
        this.dataGridView1.DataSource = dictionary.ToDataTable();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        dictionary.UpdateFromDataTable(this.dataGridView1.DataSource as DataTable);
    }
