    public MenClothing(string text)
    {
        InitializeComponent();
        txtUsername.Text = text;
        connect.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C: \Users\Teronkee\Desktop\OFFICAL STAC\OFFICAL STAC\StacProductions\DatabaseSaveItem.accdb";
    }
