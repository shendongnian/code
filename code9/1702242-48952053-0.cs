    public MainActionViewModel()
    {
        ObservableCollection<BaseType> views = new ObservableCollection<BaseType>
                {
                    new InspectionsViewModel(),
                    new SecurityViewModel()
                };
        Views = views;
    }
