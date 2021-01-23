    new List<DataRepeaterItem> items = new List<DataRepeaterItem>();
    void HandleItem(DataRepeaterItem item)
    {
        if (items.Contains(item))
            return;
        var handler = new DataRepeaterItemHelper(item);
        items.Add(item);
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        //Load data and put data in dataRepeater1.DataSource
        var db = new TestDBEntities();
        this.dataRepeater1.DataSource = db.Category.ToList();
        this.dataRepeater1.Controls.OfType<DataRepeaterItem>().ToList()
            .ForEach(item => HandleItem(item));
        this.dataRepeater1.DrawItem += dataRepeater1_DrawItem;
    }
    void dataRepeater1_DrawItem(object sender, DataRepeaterItemEventArgs e)
    {
        HandleItem(e.DataRepeaterItem);
    }
