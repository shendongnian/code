    public class TestViewModel : INotifyPropertyChanged
    {
        public TestViewModel()
        {
            ViewModelList = new ObservableCollection<TestModel>();
            ViewModelList.Add(new TestModel { ShowText = "this is first test" });
            ViewModelList.Add(new TestModel { ShowText = "this is second test" });
            ViewModelList.Add(new TestModel { ShowText = "this is third test" });
    
            var dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();
        }
    
        int i;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    
        private void dispatcherTimer_Tick(object sender, object e)
        {
            i++;
            ViewModelList = new ObservableCollection<TestModel>();
            ViewModelList.Add(new TestModel { ShowText = "this is first test" + ">>" + i });
            ViewModelList.Add(new TestModel { ShowText = "this is second test" + ">>" + i });
            ViewModelList.Add(new TestModel { ShowText = "this is third test" + ">>" + i });
        }
    
        private ObservableCollection<TestModel> _ViewModelList;
        public ObservableCollection<TestModel> ViewModelList
        {
            get
            {
                return _ViewModelList;
            }
            set
            {
                _ViewModelList = value;
                RaisePropertyChanged("ViewModelList");
            }
        }
    }
