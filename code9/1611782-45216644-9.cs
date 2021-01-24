     public class MyViewModel : ViewModelBase
    {            
        private bool _isLoading;
        public bool IsLoading
        {
          get { return _isLoading; }
          set
          {
            if(_isLoading == value) return;
             _isLoading = value;
             OnPropertyChanged();
          }
    }
