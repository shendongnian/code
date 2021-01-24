    public class MyClass : INotifyPropertyChanged
    {
        private ObservableCollection<CProyecto> prope;
        public ObservableCollection<CProyecto> Prope
        {
            get { return prope; }
            set { prope = value; RaisePropertyChanged(nameof(Prope)); }
        }
        public MyClass()
        {
            // Don't wait or await.  When it's ready
            // the UI will get notified.
            LoadData();
        }
        async private Task LoadData() 
        {
            Prope = await clsStaticClassDataLoader.GetDataFromWebService();
        }
    }
