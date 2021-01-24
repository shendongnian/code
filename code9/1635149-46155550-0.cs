    private Int32 MaxRows { get; set; }
    public Form1()
    {
        MaxRows = 10;
        InitializeComponent();
    }
    public void button1_Click(object sender, EventArgs e)
    {
        if (dataGridView1.Rows.Count <= MaxRows)
        this.dataGridView1.Rows.Add("This is a row.");
    }
