    public class Test
    {
        public int X { get; set; }
        public decimal? Y { get; set; }
    }
    BindingList<Test> list;
    decimal? defaultValue = 100; //Some default value
    string defaultFormattedValue = "<Default>"; //Some default formatted value
    private void Form1_Load(object sender, EventArgs e)
    {
        list = new BindingList<Test>(new List<Test>());
        this.dataGridView1.DataSource = list;
    }
    private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
        var value = string.Format("{0}", e.Value);
        if (value == string.Empty || value == "\"\"")
            e.Value = defaultValue;
        e.ParsingApplied = true;
    }
    private void dataGridView1_CellFormatting(object sender, 
        DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value is int? && (int?)e.Value == defaultValue)
            e.Value = defaultFormattedValue;
    }
