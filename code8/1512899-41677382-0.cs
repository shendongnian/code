    public Form1()
    {
        InitializeComponent();
        connection = new SQLiteConnection("Data Source=BddTest.s3db;Version=3;");
        search();}
