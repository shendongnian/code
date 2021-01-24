    private const string TestDataFilePath = @"C:\test\TestData.xml";
    private readonly XmlSerializer _serializer = new XmlSerializer(typeof(DataModel[]));
    private DataModel[] Items { get; set; }
    public Form1()
    {
        InitializeComponent();
        Load += LoadData;
        btnSave.Click += SaveData;
    }
    private void SaveData( object sender, EventArgs e )
    {
        using (var file = File.Create(TestDataFilePath))
        {
            _serializer.Serialize(file, Items);
        }
    }
    private void LoadData( object sender, EventArgs eventArgs )
    {
        using ( var file = File.Open( TestDataFilePath, FileMode.Open ))
        {
            Items = (DataModel[])_serializer.Deserialize( file );
        }
        dataGridView1.DataSource = Items;
    }
