    public MainWindow()
    { 
        InitializeComponent();
        lv.ItemsSource = new Item[3] { new Item() { IsNotCalibratedYet=true }, new Item() { IsNotCalibratedYet = false }, new Item() { IsNotCalibratedYet = true } };
        gv.Columns.Add(new GridViewColumn()
        {
             DisplayMemberBinding = new Binding("IsNotCalibratedYet"),
        });
    } 
