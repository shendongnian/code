     public class MainWindowViewmodel
        {
            private object selectedViewModel;
            public object SelectedViewModel
            {
                get
                {
                    return selectedViewModel;
                }
                set
                {
                    selectedViewModel = value;
                    OnPropertyChanged("SelectedViewModel");
                }
            }
            public MainWindowViewmodel()
            {
                SelectedViewModel = new page1viewmodel();
            }
        }
    
