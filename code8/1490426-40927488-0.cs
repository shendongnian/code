    public ServiceListPage()
        {
            InitializeComponent();
			this.BindingContext = new ViewModels.ServiceListViewModel(Plugin.BLE.CrossBluetoothLE.Current.Adapter, UserDialogs.Instance);
        }
