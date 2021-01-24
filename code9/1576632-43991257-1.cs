    public class ViewModel
    {
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ViewModel()
        {
            EditCommand = new RelayCommand(() =>
            {
                //TODO
                System.Diagnostics.Debug.WriteLine("EditCommand");
            });
            DeleteCommand = new RelayCommand(() =>
            {
                //TODO
                System.Diagnostics.Debug.WriteLine("DeleteCommand");
            });
        }
    }
