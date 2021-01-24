    private DataGridView dgNew;
    
    public MyForm()
    {
        InitializeComponent();
        MyInitializeComponent();
    }
    
    private void MyInitializeComponent()
    {
        dgNew = new DataGridView();
    
        var txtCol = new DataGridViewTextBoxColumn
        {
            HeaderText = "Column1",
            Name = "Column1",
            DataPropertyName = "Value"
        };
        dgNew.Columns.Add(txtCol);
    
        txtCol = new DataGridViewTextBoxColumn
        {
            HeaderText = "Column2",
            Name = "Column2",
        };
        dgNew.Columns.Add(txtCol);
    
        var listOfStrings = new List<string> {"one", "two", "three"};
        dgNew.DataSource = listOfStrings.ConvertAll(x => new { Value = x }); ;
        dgNew.Location = dg.Location;
        dgNew.Parent = this;
    
        this.Load += Form_Load;
    }
    
    private void Form_Load(object sender, EventArgs e)
    {
        // Iterate over the rows, ignoring the header row
        foreach (var row in dgNew.Rows.OfType<DataGridViewRow>().Where(a => a.Index != -1))
        {
            var col1Value = row.Cells["Column1"].Value?.ToString();
            var col2Cell = row.Cells["Column2"];
    
            if (col1Value == null) continue;
    
            switch (col1Value)
            {
                case ("one"):
                    col2Cell.Value = "row1, col2 val";
                    break;
                case ("two"):
                    col2Cell.Value = "row2, col2 val";
                    break;
                case ("three"):
                    col2Cell.Value = "row1, col3 val";
                    break;
            }
        }
    }
