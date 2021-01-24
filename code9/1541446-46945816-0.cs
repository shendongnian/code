    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Views = new ObservableCollection<ViewModelBase>
            {
                new SomeViewModel1(),
                new SomeViewModel2()
                new SomeViewModel3(),
                new SomeViewModel4()
            };
        }
    
        public ObservableCollection<ViewModelBase> Views { get; set; }
    }
