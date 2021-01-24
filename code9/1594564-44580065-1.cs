    public ICollectionView ModulesView
    {
        get { return _ModulesView; }
        set
        {
            _ModulesView = value;
            NotifyPropertyChanged();
        }
    }
    private ObservableCollection<Module> myModulesList;
    private void RefreshModule()
    {
        myModulesList = new ObservableCollection<Module>(sdb.GetModules().OrderBy(mod => mod.Address));
        ModulesView = CollectionViewSource.GetDefaultView(myModulesList);
        ModulesView.Filter = obj =>
            {
                var Module = (Module)obj;
                return SelectedProduct != null && SelectedProduct.ModelNumber == Module.ModelNumber;
            };
    }
