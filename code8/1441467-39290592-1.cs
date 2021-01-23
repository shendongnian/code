    public class MainWindowViewModel:ViewModelBase
    {
            private ViewModelBase _CurrentView; //ViewModelBase or any common class,or interface of both types of views. 
            private ViewModelBase CurrentView
            {
                get
                {
                    return _CurrentView;
                }
                set
                {
                    if(_CurrentView != value)
                    {
                        _CurrentView = value;
                        OnPropertyChanged();
                    }
                }
            }
    }
