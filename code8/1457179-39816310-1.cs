    private ObservableCollection<SalesPeriodV> salesPeriods = new ObservableCollection<SalesPeriodV>();
    public ObservableCollection<SalesPeriodV> SalesPeriods
    {
        get { return salesPeriods; }
        set { salesPeriods = value; OnPropertyChanged("SalesPeriods"); }
    }
    private SalesPeriodV selectedItem = new SalesPeriodV();
    public SalesPeriodV SelectedItem
    {
        get { return selectedItem; }
        set { selectedItem = value; OnPropertyChanged("SelectedItem"); }
    }
    private void _ComboBoxCurrencyExchange_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox cb = (ComboBox)sender;
        SelectedItem = (SalesPeriodV)(cb.SelectedItem);
        string text = cb.SelectedValue.ToString();
    }
