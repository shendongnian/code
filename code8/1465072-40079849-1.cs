    constructor()
    {
        InitializeComponent();
        // Alternatively put this in an initialization method.
        _oCollectionView.Filter = DoFilter;
    }
    private async void OnFilterTextBoxTextChangedHandler(object oSender, TextChangedEventArgs oArgs)
    {
        // Other operations
        // Asynchronous processing
        await SetupFilterAsync();
        _oCollectionView.Refresh();
    }
    private async Task SetupFilterAsync()
    {
        // Do whatever you need to do async.
    }
    private bool DoFilter(object obj)
    {
        // Cast object to the type your CollectionView is holding
        var myObj = (MyType) obj;
        // Determine whether that element should be filtered
        return myObj.ShouldBeFiltered;
    }
