    private void Form1_Load(object sender, EventArgs e)
    {
        var t = new DataTable();
        var tc = t.Clone();
        t.Columns.Add("C1");
        t.Rows.Add("A");
        t.Rows.Add("B");
        t.Rows.Add("C");
        t.Rows.Add("D");
        t.Rows.Add("E");
        currentBS.PositionChanged += (x, y) =>
        {
            if (currentBS.Position == 0)
                previousBS.DataSource = tc;
            else
            {
                previousBS.DataSource = t;
                previousBS.Position = this.currentBS.Position - 1;
            }
            if (currentBS.Position == currentBS.Count - 1)
                nextBS.DataSource = tc;
            else
            {
                nextBS.DataSource = t;
                nextBS.Position = this.currentBS.Position + 1;
            }
        };
        previousBS.DataSource = tc;
        nextBS.DataSource = tc;
        currentBS.DataSource = t;
        this.previousTextBox.DataBindings.Add("Text", previousBS, "C1");
        this.currentTextBox.DataBindings.Add("Text", currentBS, "C1");
        this.nextTextBox.DataBindings.Add("Text", nextBS, "C1");
    }
