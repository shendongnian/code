    public class MainViewModel : ViewModelBase // Not sure why you didn't subclass ViewModelBase in your question
    {
        private MySpecialViewModel _mySpecialViewModel;
        public MySpecialViewModel MySpecialViewModel
        {
            get
            {
                return _mySpecialViewModel;
            }
            set
            {
                if (value != _mySpecialViewModel)
                {
                    _mySpecialViewModel = value;
                    RaisePropertyChanged(); // The property changed method call
                }
            }
        }
        public MainViewModel()
        {
            MySpecialViewModel = new MySpecialViewModel();
            //gets not displayed!
            Task.Run(() => MySpecialViewModel.changeImage(5000, "C:\\Users\\user\\Pictures\\Capture.PNG"));
        }
    }
