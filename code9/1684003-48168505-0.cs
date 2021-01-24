    public Form1(string tableName)
    {
        InitializeComponent();
        bs = new BindingSource();
        //Set it here
        this.DatabaseTableName = tableName;
        this.PopulateDataGridView();
    }
