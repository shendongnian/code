    private ObservableCollection<MyDummyUser> dataFromSQLService;
        public ObservableCollection<MyDummyUser> DataFromSQLService
        {
            get { return dataFromSQLService; }
            set { dataFromSQLService = value; RaisePropertyChanged(nameof(DataFromSQLService)); }
        }
