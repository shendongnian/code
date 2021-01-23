    public class MainViewModel : ViewModelBase
    {
        public MySpecialViewModel SpecialViewModel
        { 
            get { return _specialViewModel; }
            set
            {
              if (value != _specialViewModel)
              {
                 _specialViewModel= value;
                 RaisePropertyChanged("SpecialViewModel");
              }
            } 
         }
    
        private MySpecialViewModel _specialViewModel;
        
            public MainViewModel()
            {
                MySpecialViewModel = new MySpecialViewModel();
                //gets not displayed!
                Task.Run(() => MySpecialViewModel.changeImage(5000, "C:\\Users\\user\\Pictures\\Capture.PNG"));
            }
        }
