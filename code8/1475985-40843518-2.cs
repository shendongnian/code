    public enum MyEnum { First, Second, Third }
    private void Form1_Load(object sender, EventArgs e)
    {
        var dt = new DataTable();
        dt.Columns.Add("C1", typeof(bool));
        dt.Columns.Add("C2", typeof(MyEnum));
        dt.Columns.Add("C3", typeof(string));
        dt.Rows.Add(true, MyEnum.First, "test");
        this.dataGridView1.DataSource = dt;
        UseComboBoxForEnumsAndBools(this.dataGridView1);
    }
