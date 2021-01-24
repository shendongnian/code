    public static readonly DependencyProperty CurrentDataProperty =
            DependencyProperty.Register(
                "CurrentData",
                typeof(DataGridCollectionView),
                typeof(XceedDataGridWrapper),
                new UIPropertyMetadata(null));
    public DataGridCollectionView CurrentData
    {
        get { return mviewSource; }
    }
