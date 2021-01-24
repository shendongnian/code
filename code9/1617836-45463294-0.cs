    public Bill()
    {
        InitializeComponent();
    }
    
    public void init(string code, string name, string email)
    {
        grid.Rows.Add();
        grid.Rows[0].Cells[0].Value = code;
        grid.Rows[0].Cells[1].Value = name;
        grid.Rows[0].Cells[2].Value = email;
    }
