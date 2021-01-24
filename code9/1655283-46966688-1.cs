    public MainWindow()
    {
    	InitializeComponent();
    	LoadDatagrid();
    }
    
    public void LoadDatagrid()
    {
        LagerDBEntities1 dataEntities = new LagerDBEntities1();          
        var query =
               from product in dataEntities.Artikel
               select new { product.Id, product.artikelname, product.bestand };            
               dataGrid1.ItemsSource = query.ToList();
    }
