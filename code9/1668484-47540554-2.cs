    public MainWindow()
    {
        InitializeComponent();
        var cvs = FindResource("MyCollectionViewSource1") as CollectionViewSource;
        var dpdView = DependencyPropertyDescriptor.FromProperty(
                          CollectionViewSource.ViewProperty, typeof(CollectionViewSource));
        dpdView.AddValueChanged(cvs, (s, e) =>
        {
            if (cvs.View is ListCollectionView lvc)
            {
                lvc.CustomSort = new CustomSorter();
            }
        });
    }
