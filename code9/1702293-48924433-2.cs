    public class DiscountPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DiscountModel> _lister;
        public event PropertyChangedEventHandler PropertyChanged;
        //initalize variables here
        RestService service = new RestService();
        public ObservableCollection<DiscountModel> lister
        {
            get => _lister;
            set
            {
                _lister = value;
                OnPropertyChanged();
            }
        }
        public DiscountPageViewModel()
        {
            Get_Data();
        }
        //get data
        async void Get_Data()
        {
            lister = await service.Get_Data<DiscountModel>("discount");
        }
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }
    }
